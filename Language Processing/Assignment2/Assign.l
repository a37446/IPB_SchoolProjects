%{
#include "y.tab.h"
#include <stdlib.h>
#include <string.h>
%}
%option yylineno
%option noyywrap
%%

-?[0-9]+[.][0-9]+ {yylval.val=atof(yytext); return NUM;}
[ \n\t\r] ;
[,\[\]{};():=] { return yytext[0];}

\"prop0\" {return PROP0;}
\"prop1\" {return PROP1;}
\"value0\" {return VALUE0;}
\"features\" { return FEATURES;}
\"Feature\" {return FEATURE;}
\"FeatureCollection\" {return FEATURECOLLECTION;}
\"Polygon\" {return POLYGON;}
\"geometry\" { return GEOMETRY;}
\"properties\" {return PROPERTIES;}
\"type\" {return TYPE;}
\"Point\" {return POINT;}
\"LineString\" { return LINESTRING;}
\"coordinates\" {return COORDINATES;}
\"this\" { return THIS;}
\"that\" {return THAT;}



%%

