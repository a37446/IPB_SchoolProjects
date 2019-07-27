%{
#include <stdio.h>
int yylex();
int yyerror(char *);
%}
%token NUM
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
%token POLYGON 
%token LINESTRING
%token THIS
%token THAT
%start suru
%%
suru : 
     | next
     ;

next :'{'TYPE ':' FEATURECOLLECTION ',' FEATURES ':' '['features ']''}' ; {printf("\n");}

features:
         |'{'featurelist'}' comma features {printf("\n");}       
         ;
comma:
     |',' 
     ;

featurelist:
           |arg {printf("\n");}
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

polygon:'{' TYPE ':' POLYGON ',' COORDINATES ':' lstt'}'; {printf("\n");}

linestring:'{' TYPE ':' LINESTRING ',' COORDINATES ':' lstt'}'; {printf("\n");}

point : '{' TYPE ':' POINT ',' COORDINATES ':' lst '}'  ; {printf("\n");}

lst:'['NUM ',' NUM']';

lstt: '[' lstelem ']';

lstelem: lst
       |lst ',' lstelem
       ;
       
%%
int main(){
  yyparse();
  return 0;
}

int yyerror(char *msg){
    fprintf(stderr,"%s\n",msg);
  return 0;
}
