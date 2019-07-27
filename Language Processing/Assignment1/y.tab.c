#ifndef lint
static char yysccsid[] = "@(#)yaccpar 1.8 (Berkeley) 01/20/91";
#endif
#define YYBYACC 1
#line 2 "Assign.y"
#include <stdio.h>
int yylex();
int yyerror(char *);
#line 10 "y.tab.c"
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
    0,    0,    1,    2,    2,    4,    4,    3,    3,    5,
    5,    5,    7,    8,    8,    8,    9,    9,   10,   10,
    6,    6,    6,   13,   12,   11,   15,   14,   16,   16,
};
short yylen[] = {                                         2,
    0,    1,   11,    0,    5,    0,    1,    0,    1,    5,
    5,    7,    1,    0,    5,    5,    5,    1,    1,    1,
    1,    1,    1,    9,    9,    9,    5,    3,    1,    3,
};
short yydefred[] = {                                      0,
    0,    0,    2,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    9,    0,    0,    0,
    0,    0,    3,    0,    0,   21,   22,   23,    0,    0,
    7,    0,    0,    0,    0,    0,    0,    0,   13,    5,
    0,   11,   10,    0,    0,    0,    0,    0,    0,    0,
   18,    0,    0,    0,    0,    0,    0,    0,   19,   20,
    0,    0,   12,    0,    0,    0,   15,    0,   16,    0,
    0,    0,    0,    0,    0,    0,    0,    0,   17,    0,
    0,   24,    0,   26,   25,    0,   28,    0,   30,    0,
   27,
};
short yydgoto[] = {                                       2,
    3,   12,   16,   32,   17,   25,   38,   39,   53,   61,
   26,   27,   28,   75,   80,   81,
};
short yysindex[] = {                                   -118,
 -241,    0,    0,  -36, -236,  -20, -231,  -30,  -61,  -92,
 -251,  -59,  -23,  -22,  -19,  -88,    0,  -87,  -83, -220,
  -81,   -1,    0, -218,   -1,    0,    0,    0,   -1, -247,
    0,  -92,  -13, -251, -251,  -12,  -11,  -77,    0,    0,
 -255,    0,    0, -216, -121,   -1,    6,    7,    8,   -1,
    0, -252,   -1, -251, -213, -212, -211, -247,    0,    0,
   -2, -247,    0,    1,    2,    3,    0, -252,    0,  -34,
  -33,  -34,  -63,  -33,  -62, -193,  -60,  -58,    0,   22,
  -25,    0,   25,    0,    0,  -33,    0, -187,    0,  -18,
    0,
};
short yyrindex[] = {                                     71,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  -17,
  -53,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,  -90,    0,    0, -125,    0,    0,    0, -125,  -52,
    0,  -17,    0,  -53,  -53,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0, -125,    0,    0,    0, -124,
    0,    0, -124,  -53,    0,    0,    0,  -52,    0,    0,
    0,  -52,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,  -16,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,
};
short yygindex[] = {                                      0,
    0,   42,  -28,  -21,    0,    0,  -48,    0,    0,   10,
    0,    0,    0,    9,   11,   -7,
};
#define YYTABLESIZE 144
short yytable[] = {                                       6,
    6,   52,    6,   34,    1,   42,   43,   35,   13,   67,
   14,   47,   48,   69,   49,   36,   37,   15,   59,   60,
    4,    5,    6,    7,   54,   63,    8,    9,   58,   10,
   11,   62,    6,   18,   19,   20,   22,   23,   21,   24,
   29,   30,   31,   33,   41,   44,   45,   46,   50,   55,
   56,   57,   64,   65,   66,   68,   74,   76,   70,   71,
   72,   79,   82,   83,   84,   86,   85,   87,   88,   90,
    1,    8,   14,   40,   91,    4,   29,   73,   89,    0,
   78,   77,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    6,   51,    6,    0,    6,    6,
    0,    0,    0,    6,
};
short yycheck[] = {                                     125,
  125,  123,   93,   25,  123,   34,   35,   29,  260,   58,
  262,  267,  268,   62,  270,  263,  264,  269,  271,  272,
  262,   58,  259,   44,   46,   54,  258,   58,   50,   91,
  123,   53,  123,   93,   58,   58,  125,  125,   58,  123,
  261,  123,   44,  262,   58,   58,   58,  125,  265,   44,
   44,   44,  266,  266,  266,   58,   91,   91,   58,   58,
   58,  125,  125,  257,  125,   44,  125,   93,   44,  257,
    0,  125,  125,   32,   93,   93,   93,   68,   86,   -1,
   72,   71,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,  260,  257,  262,   -1,  263,  264,
   -1,   -1,   -1,  269,
};
#define YYFINAL 2
#ifndef YYDEBUG
#define YYDEBUG 0
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
"suru : next",
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
"linestring : '{' TYPE ':' LINESTRING ',' COORDINATES ':' lstt '}'",
"point : '{' TYPE ':' POINT ',' COORDINATES ':' lst '}'",
"lst : '[' NUM ',' NUM ']'",
"lstt : '[' lstelem ']'",
"lstelem : lst",
"lstelem : lst ',' lstelem",
};
#endif
#ifndef YYSTYPE
typedef int YYSTYPE;
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
#line 82 "Assign.y"
int main(){
  yyparse();
  return 0;
}

int yyerror(char *msg){
    fprintf(stderr,"%s\n",msg);
  return 0;
}
#line 207 "y.tab.c"
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
case 3:
#line 29 "Assign.y"
{printf("\n");}
break;
case 5:
#line 32 "Assign.y"
{printf("\n");}
break;
case 9:
#line 39 "Assign.y"
{printf("\n");}
break;
case 24:
#line 67 "Assign.y"
{printf("\n");}
break;
case 25:
#line 69 "Assign.y"
{printf("\n");}
break;
case 26:
#line 71 "Assign.y"
{printf("\n");}
break;
#line 371 "y.tab.c"
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
