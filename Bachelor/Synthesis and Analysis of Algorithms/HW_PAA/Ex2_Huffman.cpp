#include <stdio.h>
#include <stdlib.h>
#include <iostream>

#define MAX 256 // ���������� ���� ������� - ASCII
//#define MSG "AAABAABAACAABAACACAACBAACBAACAAC"
#define MSG "AABBBCCDDDDDEEECCAACDDEECEDEDEDEABCABCDE"
//#define MSG "afbabcdefacbabcdecde"

struct tree {
	char sym; /* ������ (�����) */
	unsigned freq; /* ������� �� ������� �� ������� */
	struct tree *left, *right; /* ��� � ����� ���������� */
};

struct {
	unsigned weight; /* ����� �� ������� */
	struct tree *root; /* ������� */
} forest[MAX]; /* ����: ����� �� ������� */
unsigned treeCnt; /* ���� ������� � ������ */
char code[MAX]; /* ��� �� ������ �� ��������� ������ */

void initModel(char *msg) /* ������ ��������� �� ������� �� ��������� */
{
	char *c = msg;
	unsigned freqs[MAX]; /* ������� �� ������� �� ��������� */
	unsigned i;
	/* ����������� �� ������� �� ��������� �� ������� */
	for (i = 0; i < MAX; i++)
		freqs[i] = 0;
	while (*c)
		freqs[(unsigned char)*c++]++;
	/* �� ����� ������ � �������� ������� �� ������� ��������� ����� */
	for (treeCnt = i = 0; i < MAX; i++)
		if (freqs[i]) {
			forest[treeCnt].weight = freqs[i];
			forest[treeCnt].root = (struct tree *) malloc(sizeof(struct tree));
			forest[treeCnt].root->left = NULL;
			forest[treeCnt].root->right = NULL;
			forest[treeCnt].root->freq = freqs[i];
			forest[treeCnt++].root->sym = i;
		}
}

/* ������ ����� ���-����� �������� */
void findMins(unsigned *min,
unsigned *secondMin) /* ������ ����� ���-����� �������� */
{ unsigned i;
if (forest[0].weight <= forest[1].weight) {
*min = 0;
*secondMin = 1;
}
else {
*min = 1;
*secondMin = 0;
}
for (i = 2; i < treeCnt; i++)
if (forest[i].weight <= forest[*min].weight) { /* <-- */
*secondMin = *min;
*min = i;
}
else if (forest[i].weight <= forest[*secondMin].weight) /* <-- */
*secondMin = i;
}

void huffman(void)
{ unsigned i,j;
struct tree *t;
while (treeCnt > 1) {
findMins(&i,&j); /* �������� �� ����� ���-����� ����� */
/* ��������� �� ��� ����� - ���������� �� ����� ���-����� */
t = (struct tree *) malloc(sizeof(*t));
if (i < j) { /* <-- */
t->left = forest[i].root; /* <-- */
t->right = forest[j].root; /* <-- */
} /* <-- */
else { /* <-- */
t->right = forest[i].root; /* <-- */
t->left = forest[j].root; /* <-- */
} /* <-- */
forest[i].weight += forest[j].weight;
forest[i].root = t;
/* j-���� ����� �� � ����� ������. ���������� � ����������. */
forest[j] = forest[--treeCnt];
}
}

void printTree(struct tree *t, unsigned h) /* ������� ������� */
{
	unsigned i;
	if (t) {
		printTree(t->left, h + 1);
		for (i = 0; i < h; i++)
			printf(" ");
		printf("%4d", t->freq);
		if (NULL == t->left)
			printf(" %c", t->sym);
		printf("\n");
		printTree(t->right, h + 1);
	}
}

void writeCodes(struct tree *t, unsigned index) /* ������� �������� */
{
	if (t) {
		code[index] = '0';
		writeCodes(t->left, index + 1);
		if (NULL == t->left) {/* ����� ���� ��� 0 ��� 2 ���������� */
			code[index] = '\0';
			printf("%c = %s\n", t->sym, code);
		}
		code[index] = '1';
		writeCodes(t->right, index + 1);
	}
}

int main(void)
{
	setlocale(LC_ALL, "BGR");
	initModel(MSG);
	huffman();
	printf("����� �� ������ �� \n%s\n", MSG);
	printTree(forest[0].root, 0);
	printf("\n��� �� ������:\n");
	writeCodes(forest[0].root, 0);
	return 0;
}
