#include <iostream>
#include <vector>
#include <stdlib.h>

using namespace std;

const unsigned n = 10;

int graph[n][n] =
{
	{ 0, 6, 0, 0, 0, 0, 0, 0, 0, 0 }, //0  | �,�,�,� / - / �
	{ 6, 0, 4, 0, 0, 0, 0, 0, 0, 0 }, //1  | �,� / �,� / �
	{ 0, 4, 0, 7, 5, 0, 0, 0, 0, 0 }, //2  | �,�,� / � / �
	{ 0, 0, 7, 0, 0, 6, 0, 0, 0, 0 }, //3  | � / �,�,� / �
	{ 0, 0, 5, 0, 0, 0, 6, 0, 0, 0 }, //4  | � / �,�,� / � 
	{ 0, 0, 0, 6, 0, 0, 0, 5, 0, 0 }, //5  | �,�,� / � / �
	{ 0, 0, 0, 0, 6, 0, 0, 7, 0, 0 }, //6  | �,�,� / � / �
	{ 0, 0, 0, 0, 0, 5, 7, 0, 4, 0 }, //7  | � / �,�,� / �
	{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 6 }, //8  | �,� / �,� / �
	{ 0, 0, 0, 0, 0, 0, 0, 0, 6, 0 }  //9  | - / �,�,�,� / �
};

string lblStates[n] =
{
	"�,�,�,� / - / �", "�,� / �,� / �", "�,�,� / � / �",
	"� / �,�,� / �", "� / �,�,� / �", "�,�,� / � / �",
	"�,�,� / � / �", "� / �,�,� / �", "�,� / �,� / �",
	"- / �,�,�,� / �"
};

char used[n];
unsigned path[n], count;

// ������ ������ ������ ������ ����� ��������� i � j
void DFS(unsigned i, unsigned j)
{
	unsigned k;
	if (i == j) {
		path[count] = j;	
		for (unsigned ind = 0; ind <= count; ind++)
			printf("%s\n", lblStates[path[ind]].c_str());
		printf("\n");
		system("pause");
		exit(1);
	}
	// ��������� �� ��������� ����
	used[i] = 1;
	path[count++] = i;
	for (k = 0; k < n; k++) // �������� �� ������ ������ �� i
		if (graph[i][k] && !used[k])
			DFS(k, j);
	// �������: ������������ �� ��������� ����
	used[i] = 0; 
	count--;
}

int main(void) {
	setlocale(LC_ALL, "BGR");
	unsigned sv = 0, ev = 9;

	DFS(sv, ev);
	cout << endl;

	return 0;
}
