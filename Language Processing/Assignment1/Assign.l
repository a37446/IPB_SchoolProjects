%{
#include "y.tab.h"
#include <stdlib.h>
#include <string.h>
%}
%option yylineno
%option noyywrap
%%

[1-9][0-9]*|0|[0-9]+\.[0-9] {printf("%s(NUM)",yytext); return NUM;}
[ \n\t\r] ;
[,\[\]{};():=] {printf("%s ",yytext); return yytext[0];}

\"prop0\" {printf("PROP0 "); return PROP0;}
\"prop1\" {printf("PROP1 "); return PROP1;}
\"value0\" {printf("VALUE0 "); return VALUE0;}
\"features\" {printf("FEATURES "); return FEATURES;}
\"Feature\" {printf("FEATURE "); return FEATURE;}
\"FeatureCollection\" {printf("FEATURECOLLECTION "); return FEATURECOLLECTION;}
\"Polygon\" {printf("POLYGON "); return POLYGON;}
\"geometry\" {printf("GEOMETRY "); return GEOMETRY;}
\"properties\" {printf("PROPERTIES "); return PROPERTIES;}
\"type\" {printf("TYPE "); return TYPE;}
\"Point\" {printf("POINT "); return POINT;}
\"LineString\" {printf("LINESTRING "); return LINESTRING;}
\"coordinates\" {printf("COORDINATES "); return COORDINATES;}
\"this\" {printf("THIS "); return THIS;}
\"that\" {printf("THAT "); return THAT;}



%%

