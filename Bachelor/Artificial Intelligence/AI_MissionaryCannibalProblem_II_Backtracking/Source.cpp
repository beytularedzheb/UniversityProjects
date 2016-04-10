#include <stdlib.h>
#include <iostream>
using namespace std;

#define MAXN 20

const unsigned n = 13; // broi vurhove
const unsigned ev = 12; // kraen vruh
unsigned sv = 0; // startov vruh

const char A[MAXN][MAXN] = {
{0,3,2,3,6,0,0,0,0,0,0,0,0}, //0  | 3m3c,0,L
{3,0,0,0,0,2,0,0,0,0,0,0,0}, //1  | 2m2mc,1m1c,R
{2,0,0,0,0,1,0,0,0,0,0,0,0}, //2  | 3m1c,2c,R
{3,0,0,0,0,2,0,0,0,1,0,0,0}, //3  | 3m,3c,R
{6,0,0,0,0,0,0,0,0,0,0,0,0}, //4  | 3c,3m,R 
{0,2,1,2,0,0,6,5,0,0,0,0,0}, //5  | 3m2c,1c,L
{0,0,0,0,0,6,0,0,4,0,0,0,0}, //6  | 2c,3m1c,R
{0,0,0,0,0,5,0,0,0,4,0,0,0}, //7  | 1m1c,2m2c,R
{0,0,0,0,0,0,4,0,0,0,5,0,0}, //8  | 2m2c,1m1c,L
{0,0,0,1,0,0,0,4,0,0,6,0,0}, //9  | 3m1c,2c,L
{0,0,0,0,0,0,0,0,5,6,0,2,0}, //10 | 1c,3m2c,R
{0,0,0,0,0,0,0,0,0,0,2,0,3}, //11 | 1m1c,2m2c,L
{0,0,0,0,0,0,0,0,0,0,0,3,0}, //12 | 0,3m3c,R
};

const string StatesStr[n] = {
	"3m3c,0,L",   "2m2mc,1m1c,R", "3m1c,2c,R",
	 "3m,3c,R",   "3c,3m,R",      "3m2c,1c,L",
	 "2c,3m1c,R", "1m1c,2m2c,R",  "2m2c,1m1c,L",
	 "3m1c,2c,L", "1c,3m2c,R",    "1m1c,2m2c,L",
	 "0,3m3c,R"
};
unsigned vertex[MAXN];
char used[MAXN];
int tempLen, ti;

void addVertex(unsigned i, int depth) { 
	unsigned j, k;
	if (i == ev) { // putqt e nameren
		for (j = 0; j < ti; j++)
		{
			cout << StatesStr[vertex[j]].c_str() << endl;
		}
		cout << endl << "Razhodi: " << tempLen << endl;
		cout << endl << "----------------------" << endl;
		system("pause");
		exit(1);
	}
	if (depth > 0) {
		for (k = 0; k < n; k++) {
			if (!used[k]) { /* ako vurhut k ne uchastva v putq do momenta */
				if (A[i][k] > 0) {
					/* ako vurhut koito se dobavq e suseden na posledniq ot putq*/
					tempLen += A[i][k];
					used[k] = 1; /* markirane na k kato uchastvasht v putq */
					vertex[ti++] = k; /* dobavqne na vyrha k kym putq */
					depth--;
					addVertex(k, depth);
					used[k] = 0; /* demarkirane na k */
					tempLen -= A[i][k];
					ti--;
				}
			}
		}
	}
}

int main(void) {
	setlocale(LC_ALL, "BGR");
	unsigned i;
	tempLen = 0, ti = 1;
	for (i = 0; i < n; i++) used[i] = 0;
	used[sv] = 1; vertex[0] = sv;
	addVertex(sv, 2*n);
	
	return 0;
}

