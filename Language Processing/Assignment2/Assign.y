%{
#include <stdio.h>
#include <stdlib.h> 
#define DATA_SIZE 1000
int yylex();
extern int yylineno;
int yyerror(char *);


/*Created a file to write the javascript code*/
FILE *file;

/*used struct to hold the Coordinated together*/
typedef struct _point{float v1;float v2; struct _point * next;}point;

struct _point *Points=NULL;

//Adds the Coordinates to the node 
void newnode(struct _point *ps,float num,float num1){
     struct _point *current=ps;
     if(current==NULL){
        Points=malloc(sizeof(point));
        Points->v1=num;
        Points->v2=num1;
        Points->next=NULL;
        //printf("Number added %f %f\n",num,num1);
        return;
      }

    while(current->next!=NULL){
      current=current->next;
    }
    current->next=malloc(sizeof(point));
    current->next->v1=num;
    current->next->v2=num1;
    current->next->next=NULL;
}


//Set the nodes.
void freepoints(struct _point* p){
      struct _point* current=p;
      //if(p==NULL)return;
       while(current->next!=NULL){
          struct _point* aux=current->next;
          free(current);
          current=aux;
       }
      Points=NULL;
}


//Writes the initMap function to the javascript file
void printjs(FILE *f){
     if(f==NULL) f=stdout;
    fprintf(f,"function initMap() {var map = new google.maps.Map(document.getElementById('map'), {zoom: 3,center: {lat: 39.936769, lng:-8.112379}});\n");   
}


int sizeofstruct(struct _point* v){
   int counter=0;

    point * current=v;
   while(current!=NULL){
     current=current->next;
     counter+=1;
}
   return counter;
}


//Writes the coordinates of the nodes into the javascript file in the required format 
void printpoint(FILE *f,struct _point* v){
    if(f==NULL)f=stdout;
    int size = sizeofstruct(Points);
    point * current=v;
    while(current!=NULL){
      fprintf(f,"{ lat : %f , lng : %f },\n",current->v1, current->v2);
     current=current->next;
    }
}


//For pinning the point on the map
void printjspoint(FILE* f,struct _point* p){
   fprintf(f,"map.data.add({geometry: new google.maps.Data.Point({lat: %f, lng: %f})});\n",p->v1,p->v2);
   freepoints(p);
}

//Prints the points of the polygon
void printjspolygon(FILE* f,struct _point* p){

   fprintf(f,"[");
   printpoint(f,p);
   fprintf(f,"]");
   freepoints(p);
}


%}
%union{float val;}
%token<val> NUM
%token FEATURES
%token FEATURECOLLECTION
%token GEOMETRY
%token FEATURE
%token TYPE 
%token PROP0
%token PROP1
%token VALUE0
%token COORDINATES 
%token POLYGON
%token POINT
%token PROPERTIES
%token LINESTRING
%token THIS
%token THAT
%start suru
%%
suru : 
     | {printjs(file);} next {fprintf(file,"}");}
     ; {printpoint(NULL,Points);}

next :'{'TYPE ':' FEATURECOLLECTION ',' FEATURES ':' '['features ']''}' ; 

features:
         |'{'featurelist'}' comma features       
         ;
comma:
     |',' 
     ;

featurelist:
           |arg 
           ;

arg:TYPE ':' FEATURE comma featurelist 
   |GEOMETRY ':' geometry comma featurelist
   |PROPERTIES ':' '{' property '}' comma featurelist 
   ;

property: 
         proparg ;

proparg:
       | PROP0 ':' VALUE0 comma property
       | PROP1 ':' prop1arg  comma property
      
       ;

prop1arg:'{'prop1 ':' prop1 '}'
        | NUM ;

prop1: THIS
     |THAT ;

geometry :point 
         |linestring 
         |polygon
         ;

/*
Changed the grammar in such a way the a polygon can have atleast 3 coordinates . 
Linestring being collection of points could have one or more coordinates.
*/
polygon:'{' TYPE ':' POLYGON ',' COORDINATES ':' lstt'}'; 

linestring:'{' TYPE ':' LINESTRING ',' COORDINATES ':' lst2'}';

point : '{' TYPE ':' POINT ',' COORDINATES ':' lst1 '}'  ; {printjspoint(file,Points);}

lst1:'['NUM','NUM']'; {newnode(Points,$2,$4);}


//LineString
lst2:'[''['lstelem']'']'; {fprintf(file,"var fl=new google.maps.Polyline({ path:");printjspolygon(file,Points); fprintf(file,",geodesic: true,strokeColor: '#FF0000', strokeOpacity: 1.0,strokeWeight: 2}); fl.setMap(map);");}
    
lst:'['NUM ',' NUM']';{newnode(Points,$2,$4);}

lstt: '['    {fprintf(file,"map.data.add({geometry: new google.maps.Data.Polygon([");} cords']';{fprintf(file,"])})");}


//Polygon with 1 or more innercords.
cords:cords1 {printjspolygon(file,Points);}
     |cords1 {printjspolygon(file,Points);} ','  { fprintf(file,",");} cords    
     ;

cords1:'['lst ',' lst','lstelem']'
      ;

lstelem:lst
       |lst ',' lstelem
       ;
%%
int main(){

  file=fopen("Geometry.js","w");
  yyparse();
  fclose(file);
  return 0;
}

int yyerror(char *msg){
    fprintf(stderr,"error: %s\n",msg);
    return 0;
}
