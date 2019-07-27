#include <windows.h>  
#include <GL/glut.h> 
#include <Math.h>  
#include <stdio.h>
#include <string>
#define PI 3.14159265f

char title[] = "The Ball Game(2D)";  
int windowWidth = 640;     
int windowHeight = 480;    
int windowPosX = 50;      
int windowPosY = 50;      
int refreshMillis = 30 ;
int value= 0;
int score = 0;
int level = 1;
int v = 1;
int j;
GLfloat y;
GLfloat yy;
GLfloat xx;
int color = 0;
GLint temp_sc;
char score_text[10];
char numbers[]= "0123456789";
using namespace std;

GLfloat move_x = 0.0f;
GLfloat move_y = 0.0f;

GLfloat x_cord = 6.0f;
GLfloat y_cord = 0.0f;

GLfloat ballRadius = 1.0f;   
GLuint list1;

enum MENU_TYPE
{
	MENU_RED,
	MENU_GREEN,
	MENU_BLUE,
	MENU_WHITE,
};
// Assign a default value
MENU_TYPE show = MENU_WHITE;

void menu(int item)
{
	switch (item)
	{
	case MENU_RED:
	{
		glColor3f(1, 0, 0);
	}break;
	case MENU_GREEN:
	{
		glColor3f(0, 1, 0);
	}break;
	case MENU_BLUE:
	{
		glColor3f(0, 0, 1);
	}break;
	case MENU_WHITE:
	{
		glColor3f(1, 1, 1);
	}break;
	default:
	{
		glColor3f(0.5, 0.5, 0.6);
	}break;
	}

	glutPostRedisplay();
	return;
}

void escreve(int width, int height, float x, float y, void *font, string texto) {
	float xxx = (float)x;
	float yyy = (float)y;
	//glColor3f(1, 0, 0);
	glRasterPos2f(xxx, yyy);
	for (int i = 0; i < texto.length(); i++)
		glutBitmapCharacter(font, texto.at(i));
}
void display() {
	glClear(GL_COLOR_BUFFER_BIT);  
	glMatrixMode(GL_MODELVIEW);    
	glLoadIdentity();  
	escreve(0.1, 5, -12, 8.5, GLUT_BITMAP_TIMES_ROMAN_24, "Level - 1");

	glTranslatef(move_x, -8.0f, 0.0f);
	glBegin(GL_TRIANGLE_FAN);
	
	//glColor3f(0.7f, 0.5f, 0.5f);  
	glVertex2f(0.0f, 0.0f);      
	int numSegments = 100;
	GLfloat angle;
	for (int i = 0; i <= numSegments; i++) {
		angle = i * 2.0f * PI / numSegments;
		glVertex2f(cos(angle) * ballRadius, sin(angle) * ballRadius);
	}
	glEnd();

	glLoadIdentity();
	

	if (value == 1) {

		glRasterPos2f(-8.0f,7.0f);

		temp_sc = score;
		if (score == 0) { score_text[9] = '0'; }
		for (int i = 8; i >= 0; i--)
		{
			if (temp_sc == 0) break;
			score_text[i] = numbers[temp_sc % 10];
			temp_sc /= 10;
			j = i;
		}
		for (int i = j; i < 10; i++)
		{
			glutBitmapCharacter(GLUT_BITMAP_8_BY_13, score_text[i]);
		}

		glTranslatef(0, move_y, 0);
        glTranslatef(0, 0, 0);
		glCallList(list1);
		yy= 11.0-(11.0 + move_y);
		y = yy - (-8);
		xx = 7.0 - move_x ;
		if ((y == 2) )exit(0);
        glLoadIdentity();

	


		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f,0.0f,0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(-7.0f, 15.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-6.0f, 8.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(0, 0, 0);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f, 10.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-18.0f, 15.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();
        
		glTranslatef(0, 0, 0);
		glTranslatef(-7.0f, 20.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(0, 22, 0);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f, 30.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(-7.0f, 35.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-6.0f, 38.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(0, 40, 0);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f, 45.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-7.0f, 50.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(0, 55, 0);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f, 60.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(-7.0f, 65.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-6.0f, 70.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(0, 72, 0);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f, 77.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-18.0f, 78.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, 0, 0);
		glTranslatef(-7.0f, 80.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(0, 85, 0);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f, 90.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(-7.0f, 92.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-6.0f, 95.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(0, 99, 0);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f, 100.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-7.0f, 105.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f, 110.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(-7.0f, 115.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-6.0f, 120.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(0, 125, 0);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f, 130.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-18.0f, 130.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, 0, 0);
		glTranslatef(-7.0f, 130.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(0, 140, 0);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(-14.0f, 145.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();


		glTranslatef(0, move_y, 0);
		glTranslatef(-7.0f, 150.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(-6.0f, 150.0f, 0.0f);
		glCallList(list1);
		glLoadIdentity();

		glTranslatef(0, move_y, 0);
		glTranslatef(0, 155, 0);
		glCallList(list1);
		glLoadIdentity();

		score += 0.01;
		
		glFlush();
		if(level==1)move_y -= 0.02;
		else move_y -= 0.02;
		
		if (move_y < -50)level = 2;

	}
	glutSwapBuffers();  

	
	
}

void initGL() {
	glClearColor(0.18, 0.3, 0.3, 1.0);
	
}

GLfloat Ycalc(GLfloat before, GLfloat after) {
	return before - after;
	
}
void triangle() {
	
		glPushMatrix();
		
		glBegin(GL_TRIANGLES);
		glVertex2f(x_cord, 12.0);
		glVertex2f(x_cord+1.0, 11.0);
		glVertex2f(x_cord+2, 12.0);
		glEnd();

		

	
}

void reshape(GLsizei width, GLsizei height) {
	
	if (height == 0) height = 1;                
	GLfloat aspect = (GLfloat)width / (GLfloat)height;
	glViewport(0, 0, width, height);

	glMatrixMode(GL_PROJECTION);  
	glLoadIdentity();           
	if (width >= height) {
		gluOrtho2D(-10.0 * aspect, 10.0 * aspect, -10.0, 10.0);
	}
	else {
		gluOrtho2D(-10.0, 10.0, -10.0 / aspect, 10.0 / aspect);
	}
}

void Timer(int value) {
	glutPostRedisplay();    // Post a paint request to activate display()
	glutTimerFunc(refreshMillis, Timer, 0); // subsequent timer call at milliseconds
}

void SpecialKeys(int key, int x, int y)
{
	switch(key){
	case GLUT_KEY_UP:
		if (value==0)
		{
			value = 1;
		}
		else
			value = 0;
		break;
	case GLUT_KEY_DOWN:
		glClearColor(0.0, 0.0, 0.0, 1.0);
	  break;
	case GLUT_KEY_RIGHT:
		if (move_x <= 10)
			move_x += 0.50;
		break;

	case GLUT_KEY_LEFT: 
		glTranslatef(-0.1, 0, 0);
		if (move_x >= -10)
			move_x -= 0.50;
		break;
	}

	glutPostRedisplay();
}

GLfloat distance(GLfloat y1,GLfloat x1,GLfloat circlekox) {
	GLfloat g;
	GLfloat m;
	m =x1-circlekox ;
	g = y1 - (-8);
	return sqrt((m*m) + (g*g));
}

int main(int argc, char** argv) {
	glutInit(&argc, argv);            
	glutInitDisplayMode(GLUT_DOUBLE); 
	glutInitWindowSize(windowWidth, windowHeight);  
	glutInitWindowPosition(windowPosX, windowPosY); 
	glutCreateWindow(title);     
	glutDisplayFunc(display);  
	glutReshapeFunc(reshape);     
	glutSpecialFunc(SpecialKeys);
	glutIdleFunc(display);
	glLoadIdentity();
	list1 = glGenLists(1);
	glNewList(list1, GL_COMPILE);
	glPushMatrix();
	triangle();
	glPopMatrix();
	glEndList();
	glutTimerFunc(0, Timer, 0);   
	initGL();  
	glutCreateMenu(menu);
	
	glutAddMenuEntry("Red", MENU_RED);
	glutAddMenuEntry("Green", MENU_GREEN);
	glutAddMenuEntry("Blue", MENU_BLUE);
	glutAddMenuEntry("White", MENU_WHITE);

	glutAttachMenu(GLUT_RIGHT_BUTTON);
	glutMainLoop();
	return 0;
}
