#include <stdio.h> // printf(); scanf();
#include <stdlib.h> // exit();
#include <locale.h> // setlocale(); - кирилица
#include <vector> // vector<Node> vertex;
using namespace std;
/* Максимален размер на дъската */
#define MAXN 10
/* Максимален брой правила за движение на коня */
#define MAXD 10
/* Максимална дълбочина */
#define MAX_DEPTH 30
/* Размер на дъската */
const unsigned n = 8;
/* Стартова позиция */
unsigned startX;
unsigned startY;
/* Крайна позиция */
unsigned endX;
unsigned endY;
/* Правила за движение на коня */
const unsigned maxDiff = 8;
const int diffX[MAXD] = { 1, 1, -1, -1, 2, -2, 2, -2 };
const int diffY[MAXD] = { 2, -2, 2, -2, 1, 1, -1, -1 };
unsigned board[MAXN][MAXN];
unsigned newX, newY;

struct Node {
	int x;
	int y;
};
vector<Node> vertex;

void nextMove(unsigned X, unsigned Y, unsigned i)
{
	unsigned k;
	board[X][Y] = i;
	if (X == endX && Y == endY) {
		for (int v = 0; v != vertex.size(); ++v) {
    		printf("%d %d,\t", vertex[v].x + 1, vertex[v].y + 1);
    	}
		exit(0);	
	}
	if (i >= MAX_DEPTH) { return; }
	for (k = 0; k < maxDiff; k++) {
		newX = X + diffX[k]; newY = Y + diffY[k];
		if ((newX >= 0 && newX < n && newY >= 0 && newY < n) &&
			(0 == board[newX][newY])) {
				Node n;
				n.x = newX;
				n.y = newY;
				vertex.push_back(n);
				nextMove(newX, newY, i + 1);
			}	
	}
	board[X][Y] = 0;

}
int main(void)
{
	setlocale(LC_ALL, "BGR");

	unsigned i, j;
	for (i = 0; i < n; i++)
		for (j = 0; j < n; j++) board[i][j] = 0;
	printf("Задайте стартовата позиция (1..%d) (1..%d): ", n, n);
	scanf("%d %d", &startX, &startY);
	printf("\nЗадайте крайната позиция (1..%d) (1..%d): ", n, n);
	scanf("%d %d", &endX, &endY);
	endX--;
	endY--;
	nextMove(startX - 1, startY - 1, 1);
	printf("Безуспешен опит! \n");
	
	return 0;
}
