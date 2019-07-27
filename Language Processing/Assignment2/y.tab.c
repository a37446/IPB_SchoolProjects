#ifndef lint
static char yysccsid[] = "@(#)yaccpar 1.8 (Berkeley) 01/20/91";
#endif
#define YYBYACC 1
#line 2 "Assign.y"
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

/*Adds the Coordinates to the node */
void newnode(struct _point *ps,float num,float num1){
     struct _point *current=ps;
     if(current==NULL){
        Points=malloc(sizeof(point));
        Points->v1=num;
        Points->v2=num1;
        Points->next=NULL;
        /*printf("Number added %f %f\n",num,num1);*/
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


/*Set the nodes.*/
void freepoints(struct _point* p){
      struct _point* current=p;
      /*if(p==NULL)return;*/
       while(current->next!=NULL){
          struct _point* aux=current->next;
          free(current);
          current=aux;
       }
      Points=NULL;
}


/*Writes the initMap function to the javascript file*/
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


/*Writes the coordinates of the nodes into the javascript file in the required format */
void printpoint(FILE *f,struct _point* v){
    if(f==NULL)f=stdout;
    int size = sizeofstruct(Points);
    point * current=v;
    while(current!=NULL){
      fprintf(f,"{ lat : %f , lng : %f },\n",current->v1, current->v2);
     current=current->next;
    }
}


/*For pinning the point on the map*/
void printjspoint(FILE* f,struct _point* p){
   fprintf(f,"map.data.add({geometry: new google.maps.Data.Point({lat: %f, lng: %f})});\n",p->v1,p->v2);
   freepoints(p);
}

/*Prints the points of the polygon*/
void printjspolygon(FILE* f,struct _point* p){

   fprintf(f,"[");
   printpoint(f,p);
   fprintf(f,"]");
   freepoints(p);
}


#line 101 "Assign.y"
typedef union{float val;} YYSTYPE;
#line 107 "y.tab.c"
#define NUM 257
#define FEATURES 258
#define FEATURECOLLECTION 259
#define GEOMETRY 260
#define FEATURE 261
#define TYPE 262
#define PROP0 263
#define PROP1 264
#define VALUE0 265
#define COORDINATES 266
#define POLYGON 267
#define POINT 268
#define PROPERTIES 269
#define LINESTRING 270
#define THIS 271
#define THAT 272
#define YYERRCODE 256
short yylhs[] = {                                        -1,
    0,    2,    3,    0,    1,    4,    4,    6,    6,    5,
    5,    7,    7,    7,    9,   10,   10,   10,   11,   11,
   12,   12,    8,    8,    8,   15,   14,   13,   18,   17,
   20,   22,   16,   21,   24,   25,   21,   23,   19,   19,
};
short yylen[] = {                                         2,
    0,    0,    0,    3,   11,    0,    5,    0,    1,    0,
    1,    5,    5,    7,    1,    0,    5,    5,    5,    1,
    1,    1,    1,    1,    1,    9,    9,    9,    5,    5,
    5,    0,    4,    1,    0,    0,    5,    7,    1,    3,
};
short yydefred[] = {                                      0,
    0,    0,    0,    3,    0,    4,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,   11,    0,
    0,    0,    0,    0,    5,    0,    0,   23,   24,   25,
    0,    0,    9,    0,    0,    0,    0,    0,    0,    0,
   15,    7,    0,   13,   12,    0,    0,    0,    0,    0,
    0,    0,   20,    0,    0,    0,    0,    0,    0,    0,
   21,   22,    0,    0,   14,    0,    0,    0,   17,    0,
   18,    0,    0,    0,    0,   32,    0,    0,    0,    0,
    0,   19,    0,   26,    0,   28,    0,   27,    0,    0,
    0,    0,    0,    0,    0,    0,   33,    0,    0,    0,
    0,    0,    0,   36,   29,    0,   30,   40,    0,    0,
    0,    0,   37,   31,    0,   38,
};
short yydgoto[] = {                                       1,
    4,    2,    6,   14,   18,   34,   19,   27,   40,   41,
   55,   63,   28,   29,   30,   77,   81,   79,   94,   95,
   90,   83,   91,   98,  110,
};
short yysindex[] = {                                      0,
    0, -108, -233,    0,  -26,    0, -229,  -11, -222,  -20,
  -54,  -84, -249,  -53,  -17,  -16,  -15,  -81,    0,  -80,
  -77, -214,  -75,    5,    0, -212,    5,    0,    0,    0,
    5, -240,    0,  -84,   -7, -249, -249,   -6,   -4,  -70,
    0,    0, -251,    0,    0, -209, -121,    5,   13,   14,
   15,    5,    0, -246,    5, -249, -206, -205, -204, -240,
    0,    0,    6, -240,    0,    7,    8,    9,    0, -246,
    0,  -23,  -22,  -19,  -62,    0,  -55, -186,  -52,  -14,
  -51,    0,  -13,    0,   31,    0,  -12,    0,  -12,  -10,
    0, -181, -177,   -9,   37,   38,    0,   41,   -5,   42,
   -3,  -12,  -12,    0,    0, -170,    0,    0,   45,  -13,
   -2,  -12,    0,    0,   -1,    0,
};
short yyrindex[] = {                                      3,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    1,  -32,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,  -88,    0,    0, -125,    0,    0,    0,
 -125,  -30,    0,    1,    0,  -32,  -32,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0, -125,    0,    0,
    0, -124,    0,    0, -124,  -32,    0,    0,    0,  -30,
    0,    0,    0,  -30,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
  -40,    0,    0,    0,    4,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,
};
short yygindex[] = {                                      0,
    0,    0,    0,   62,  -28,  -21,    0,    0,  -46,    0,
    0,   28,    0,    0,    0,    0,    0,    0,  -90,  -82,
   -8,    0,    0,    0,    0,
};
#define YYTABLESIZE 144
short yytable[] = {                                       8,
    8,   54,    1,   35,    8,   36,   96,   44,   45,   37,
   15,  108,   16,   69,    3,   49,   50,   71,   51,   17,
  109,  115,   38,   39,   61,   62,   56,   65,    5,    8,
   60,    7,    9,   64,    8,   10,   12,   11,   13,   20,
   21,   22,   23,   24,   25,   26,   31,   32,   33,   35,
   43,   46,   34,   47,   48,   52,   57,   58,   59,   66,
   67,   68,   82,   70,   72,   73,   74,   76,   78,   84,
   85,   80,   86,   88,   92,   99,   87,   89,   93,  100,
  102,  103,   97,  101,  104,  106,  111,  105,  112,  107,
  114,  116,   10,    6,   16,   42,   39,   75,    0,    0,
    0,  113,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    2,    0,    0,    0,    0,
    0,    0,    0,    0,    8,   53,    8,    0,    8,    8,
    0,    0,    0,    8,
};
short yycheck[] = {                                     125,
  125,  123,    0,   44,   93,   27,   89,   36,   37,   31,
  260,  102,  262,   60,  123,  267,  268,   64,  270,  269,
  103,  112,  263,  264,  271,  272,   48,   56,  262,  259,
   52,   58,   44,   55,  123,  258,   91,   58,  123,   93,
   58,   58,   58,  125,  125,  123,  261,  123,   44,  262,
   58,   58,   93,   58,  125,  265,   44,   44,   44,  266,
  266,  266,  125,   58,   58,   58,   58,   91,   91,  125,
  257,   91,  125,  125,   44,  257,   91,   91,   91,  257,
   44,   44,   93,   93,   44,   44,  257,   93,   44,   93,
   93,   93,  125,   93,  125,   34,   93,   70,   -1,   -1,
   -1,  110,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,  123,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  260,  257,  262,   -1,  263,  264,
   -1,   -1,   -1,  269,
};
#define YYFINAL 1
#ifndef YYDEBUG
#define YYDEBUG 1
#endif
#define YYMAXTOKEN 272
#if YYDEBUG
char *yyname[] = {
"end-of-file",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,"','",0,0,0,0,0,0,0,0,0,0,0,0,0,"':'",0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,"'['",0,"']'",0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,"'{'",0,"'}'",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,"NUM",
"FEATURES","FEATURECOLLECTION","GEOMETRY","FEATURE","TYPE","PROP0","PROP1",
"VALUE0","COORDINATES","POLYGON","POINT","PROPERTIES","LINESTRING","THIS",
"THAT",
};
char *yyrule[] = {
"$accept : suru",
"suru :",
"$$1 :",
"$$2 :",
"suru : $$1 next $$2",
"next : '{' TYPE ':' FEATURECOLLECTION ',' FEATURES ':' '[' features ']' '}'",
"features :",
"features : '{' featurelist '}' comma features",
"comma :",
"comma : ','",
"featurelist :",
"featurelist : arg",
"arg : TYPE ':' FEATURE comma featurelist",
"arg : GEOMETRY ':' geometry comma featurelist",
"arg : PROPERTIES ':' '{' property '}' comma featurelist",
"property : proparg",
"proparg :",
"proparg : PROP0 ':' VALUE0 comma property",
"proparg : PROP1 ':' prop1arg comma property",
"prop1arg : '{' prop1 ':' prop1 '}'",
"prop1arg : NUM",
"prop1 : THIS",
"prop1 : THAT",
"geometry : point",
"geometry : linestring",
"geometry : polygon",
"polygon : '{' TYPE ':' POLYGON ',' COORDINATES ':' lstt '}'",
"linestring : '{' TYPE ':' LINESTRING ',' COORDINATES ':' lst2 '}'",
"point : '{' TYPE ':' POINT ',' COORDINATES ':' lst1 '}'",
"lst1 : '[' NUM ',' NUM ']'",
"lst2 : '[' '[' lstelem ']' ']'",
"lst : '[' NUM ',' NUM ']'",
"$$3 :",
"lstt : '[' $$3 cords ']'",
"cords : cords1",
"$$4 :",
"$$5 :",
"cords : cords1 $$4 ',' $$5 cords",
"cords1 : '[' lst ',' lst ',' lstelem ']'",
"lstelem : lst",
"lstelem : lst ',' lstelem",
};
#endif
#define yyclearin (yychar=(-1))
#define yyerrok (yyerrflag=0)
#ifdef YYSTACKSIZE
#ifndef YYMAXDEPTH
#define YYMAXDEPTH YYSTACKSIZE
#endif
#else
#ifdef YYMAXDEPTH
#define YYSTACKSIZE YYMAXDEPTH
#else
#define YYSTACKSIZE 500
#define YYMAXDEPTH 500
#endif
#endif
int yydebug;
int yynerrs;
int yyerrflag;
int yychar;
short *yyssp;
YYSTYPE *yyvsp;
YYSTYPE yyval;
YYSTYPE yylval;
short yyss[YYSTACKSIZE];
YYSTYPE yyvs[YYSTACKSIZE];
#define yystacksize YYSTACKSIZE
#line 195 "Assign.y"
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
#line 324 "y.tab.c"
#define YYABORT goto yyabort
#define YYACCEPT goto yyaccept
#define YYERROR goto yyerrlab
int
yyparse()
{
    register int yym, yyn, yystate;
#if YYDEBUG
    register char *yys;
    extern char *getenv();

    if (yys = getenv("YYDEBUG"))
    {
        yyn = *yys;
        if (yyn >= '0' && yyn <= '9')
            yydebug = yyn - '0';
    }
#endif

    yynerrs = 0;
    yyerrflag = 0;
    yychar = (-1);

    yyssp = yyss;
    yyvsp = yyvs;
    *yyssp = yystate = 0;

yyloop:
    if (yyn = yydefred[yystate]) goto yyreduce;
    if (yychar < 0)
    {
        if ((yychar = yylex()) < 0) yychar = 0;
#if YYDEBUG
        if (yydebug)
        {
            yys = 0;
            if (yychar <= YYMAXTOKEN) yys = yyname[yychar];
            if (!yys) yys = "illegal-symbol";
            printf("yydebug: state %d, reading %d (%s)\n", yystate,
                    yychar, yys);
        }
#endif
    }
    if ((yyn = yysindex[yystate]) && (yyn += yychar) >= 0 &&
            yyn <= YYTABLESIZE && yycheck[yyn] == yychar)
    {
#if YYDEBUG
        if (yydebug)
            printf("yydebug: state %d, shifting to state %d\n",
                    yystate, yytable[yyn]);
#endif
        if (yyssp >= yyss + yystacksize - 1)
        {
            goto yyoverflow;
        }
        *++yyssp = yystate = yytable[yyn];
        *++yyvsp = yylval;
        yychar = (-1);
        if (yyerrflag > 0)  --yyerrflag;
        goto yyloop;
    }
    if ((yyn = yyrindex[yystate]) && (yyn += yychar) >= 0 &&
            yyn <= YYTABLESIZE && yycheck[yyn] == yychar)
    {
        yyn = yytable[yyn];
        goto yyreduce;
    }
    if (yyerrflag) goto yyinrecovery;
#ifdef lint
    goto yynewerror;
#endif
yynewerror:
    yyerror("syntax error");
#ifdef lint
    goto yyerrlab;
#endif
yyerrlab:
    ++yynerrs;
yyinrecovery:
    if (yyerrflag < 3)
    {
        yyerrflag = 3;
        for (;;)
        {
            if ((yyn = yysindex[*yyssp]) && (yyn += YYERRCODE) >= 0 &&
                    yyn <= YYTABLESIZE && yycheck[yyn] == YYERRCODE)
            {
#if YYDEBUG
                if (yydebug)
                    printf("yydebug: state %d, error recovery shifting\
 to state %d\n", *yyssp, yytable[yyn]);
#endif
                if (yyssp >= yyss + yystacksize - 1)
                {
                    goto yyoverflow;
                }
                *++yyssp = yystate = yytable[yyn];
                *++yyvsp = yylval;
                goto yyloop;
            }
            else
            {
#if YYDEBUG
                if (yydebug)
                    printf("yydebug: error recovery discarding state %d\n",
                            *yyssp);
#endif
                if (yyssp <= yyss) goto yyabort;
                --yyssp;
                --yyvsp;
            }
        }
    }
    else
    {
        if (yychar == 0) goto yyabort;
#if YYDEBUG
        if (yydebug)
        {
            yys = 0;
            if (yychar <= YYMAXTOKEN) yys = yyname[yychar];
            if (!yys) yys = "illegal-symbol";
            printf("yydebug: state %d, error recovery discards token %d (%s)\n",
                    yystate, yychar, yys);
        }
#endif
        yychar = (-1);
        goto yyloop;
    }
yyreduce:
#if YYDEBUG
    if (yydebug)
        printf("yydebug: state %d, reducing by rule %d (%s)\n",
                yystate, yyn, yyrule[yyn]);
#endif
    yym = yylen[yyn];
    yyval = yyvsp[1-yym];
    switch (yyn)
    {
case 2:
#line 121 "Assign.y"
{printjs(file);}
break;
case 3:
#line 121 "Assign.y"
{fprintf(file,"}");}
break;
case 4:
#line 122 "Assign.y"
{printpoint(NULL,Points);}
break;
case 28:
#line 170 "Assign.y"
{printjspoint(file,Points);}
break;
case 29:
#line 172 "Assign.y"
{newnode(Points,yyvsp[-3].val,yyvsp[-1].val);}
break;
case 30:
#line 176 "Assign.y"
{fprintf(file,"var fl=new google.maps.Polyline({ path:");printjspolygon(file,Points); fprintf(file,",geodesic: true,strokeColor: '#FF0000', strokeOpacity: 1.0,strokeWeight: 2}); fl.setMap(map);");}
break;
case 31:
#line 178 "Assign.y"
{newnode(Points,yyvsp[-3].val,yyvsp[-1].val);}
break;
case 32:
#line 180 "Assign.y"
{fprintf(file,"map.data.add({geometry: new google.maps.Data.Polygon([");}
break;
case 33:
#line 180 "Assign.y"
{fprintf(file,"])})");}
break;
case 34:
#line 184 "Assign.y"
{printjspolygon(file,Points);}
break;
case 35:
#line 185 "Assign.y"
{printjspolygon(file,Points);}
break;
case 36:
#line 185 "Assign.y"
{ fprintf(file,",");}
break;
#line 512 "y.tab.c"
    }
    yyssp -= yym;
    yystate = *yyssp;
    yyvsp -= yym;
    yym = yylhs[yyn];
    if (yystate == 0 && yym == 0)
    {
#if YYDEBUG
        if (yydebug)
            printf("yydebug: after reduction, shifting from state 0 to\
 state %d\n", YYFINAL);
#endif
        yystate = YYFINAL;
        *++yyssp = YYFINAL;
        *++yyvsp = yyval;
        if (yychar < 0)
        {
            if ((yychar = yylex()) < 0) yychar = 0;
#if YYDEBUG
            if (yydebug)
            {
                yys = 0;
                if (yychar <= YYMAXTOKEN) yys = yyname[yychar];
                if (!yys) yys = "illegal-symbol";
                printf("yydebug: state %d, reading %d (%s)\n",
                        YYFINAL, yychar, yys);
            }
#endif
        }
        if (yychar == 0) goto yyaccept;
        goto yyloop;
    }
    if ((yyn = yygindex[yym]) && (yyn += yystate) >= 0 &&
            yyn <= YYTABLESIZE && yycheck[yyn] == yystate)
        yystate = yytable[yyn];
    else
        yystate = yydgoto[yym];
#if YYDEBUG
    if (yydebug)
        printf("yydebug: after reduction, shifting from state %d \
to state %d\n", *yyssp, yystate);
#endif
    if (yyssp >= yyss + yystacksize - 1)
    {
        goto yyoverflow;
    }
    *++yyssp = yystate;
    *++yyvsp = yyval;
    goto yyloop;
yyoverflow:
    yyerror("yacc stack overflow");
yyabort:
    return (1);
yyaccept:
    return (0);
}
