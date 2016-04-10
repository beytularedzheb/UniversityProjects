#include <iostream>
#include <vector>
#include <stdlib.h>

using namespace std;

const unsigned n = 10;

int graph[n][n] =
{
	{ 0, 6, 0, 0, 0, 0, 0, 0, 0, 0 }, //0  | Ф,В,К,З / - / Л
	{ 6, 0, 4, 0, 0, 0, 0, 0, 0, 0 }, //1  | В,З / Ф,К / Д
	{ 0, 4, 0, 7, 5, 0, 0, 0, 0, 0 }, //2  | Ф,В,З / К / Л
	{ 0, 0, 7, 0, 0, 6, 0, 0, 0, 0 }, //3  | З / Ф,В,К / Д
	{ 0, 0, 5, 0, 0, 0, 6, 0, 0, 0 }, //4  | В / Ф,К,З / Д 
	{ 0, 0, 0, 6, 0, 0, 0, 5, 0, 0 }, //5  | Ф,К,З / В / Л
	{ 0, 0, 0, 0, 6, 0, 0, 7, 0, 0 }, //6  | Ф,В,К / З / Л
	{ 0, 0, 0, 0, 0, 5, 7, 0, 4, 0 }, //7  | К / Ф,В,З / Д
	{ 0, 0, 0, 0, 0, 0, 0, 4, 0, 6 }, //8  | Ф,К / В,З / Л
	{ 0, 0, 0, 0, 0, 0, 0, 0, 6, 0 }  //9  | - / Ф,В,К,З / Д
};

string lblStates[n] =
{
	"Ф,В,К,З / - / Л", "В,З / Ф,К / Д", "Ф,В,З / К / Л",
	"З / Ф,В,К / Д", "В / Ф,К,З / Д", "Ф,К,З / В / Л",
	"Ф,В,К / З / Л", "К / Ф,В,З / Д", "Ф,К / В,З / Л",
	"- / Ф,В,К,З / Д"
};

char used[n];
unsigned path[n], count;

// Намира всички прости пътища между върховете i и j
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
	// маркиране на посетения връх
	used[i] = 1;
	path[count++] = i;
	for (k = 0; k < n; k++) // рекурсия за всички съседи на i
		if (graph[i][k] && !used[k])
			DFS(k, j);
	// връщане: размаркиране на посетения връх
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
