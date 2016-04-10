#include <iostream>
#include <cstring>
#include <stdlib.h>

using namespace std;

typedef struct genList {
	char dv[10];
	genList *next;
}*gl;

typedef struct subList {
	int prod;
	subList *next;
}*sl;

gl gStart, VarStart;
sl sUp, sDown, sLeft, sRight, VarUp, VarDown, VarLeft, VarRight;

void genListCreate(gl &Head)
{
	gl last, p;
	char ch, dvP[10];
	cout << "Novo dvizhenie (d/n) ?: "; cin >> ch;
	while (ch == 'd' || ch == 'D') {
		cout << "Vyvedete dvizhenie: "; cin >> dvP;
		if ((strcmp(dvP, "nagore") == 0) ||
			(strcmp(dvP, "nadolu") == 0) ||
			(strcmp(dvP, "nadqsno") == 0) ||
			(strcmp(dvP, "nalqvo") == 0)) {
			p = new genList;
			strcpy(p->dv, dvP);
			p->next = NULL;
			if (Head == NULL)
				Head = p;
			else
				last->next = p;
			last = p;
		}
		else
			cout << "\nGreshka pri vuvezhdane!";
		cout << "\nNovo dvizhenie (d/n) ?: "; cin >> ch;
	}
}

void printGenList(gl List)
{
	cout << "\n";
	while (List) {
		cout << List->dv << "\n";
		List = List->next;
	}
}
void printSubList(sl List)
{
	while (List) {
		cout << List->prod << " ";
		List = List->next;
	}
	cout << "\n";
}
void subListCreate(char dvizhenie[], gl genL, sl &sL)
{
	sl last = NULL, p;
	int br = 0;
	for (genL; genL != NULL; genL = genL->next) {
		if (strcmp(genL->dv, dvizhenie) == 0) {
			br++;
			if (genL->next == NULL)
				goto newItem;
			goto next;
		}
		else
			if ((strcmp(genL->dv, dvizhenie) != 0) && br == 0)
				goto next;
	newItem:
		p = new subList;
		p->prod = br;
		p->next = NULL;
		if (sL == NULL)
			sL = p;
		else
			last->next = p;
		last = p;
		br = 0;
	next:;
	}
}

int VariantSpis(sl Head) {
	sl P = Head, Q;

	Q = new subList;
	cout << "\nProdulzhitelnost na dvizhenieto: ";
	cin >> Q->prod;
	Q->next = NULL;
	while (P->next)
		P = P->next;
	P->next = Q;
	return Q->prod;
}

void SubToGen(char dvizh[], gl gHead) {
	gl S = gHead, R;

	R = new genList;
	strcpy(R->dv, dvizh);
	R->next = NULL;
	while (S->next)
		S = S->next;
	S->next = R;
}

int main()
{
	gStart = NULL;
	sUp = NULL;
	sDown = NULL;
	sLeft = NULL;
	sRight = NULL;

	VarStart = new genList;
	VarUp = new subList;
	VarDown = new subList;
	VarLeft = new subList;
	VarRight = new subList;
	VarStart->next = NULL;
	VarUp->next = NULL;
	VarDown->next = NULL;
	VarLeft->next = NULL;
	VarRight->next = NULL;


	char dvizh[10], ch;
	int choise, x = 0, i;
	bool flag1 = false, flag2 = false;

	cout << "-nagore\n-nadolu\n-nadqsno\n-nalqvo\n";
	do
	{
		printf("%30sMENU\n", "");
		printf("%15s1. Vuvezhdane na spisuka s dvizheniqta\n", "");
		printf("%15s2. Razdelqne spisuka s dvizheniqta na podspisuci\n", "");
		printf("%15s3. Vizualizirane na spisuka s dvizheniqta\n", "");
		printf("%15s4. Vizualizirane na podspisuk\n", "");
		printf("%15s5. Syzdavane na 1 variant na spisuk s dvizheniqta\n", "");
		printf("%18sPosochete operaciq ili 0 za krai: ", "");
		scanf("%d", &choise); getchar();

		switch (choise)
		{
		case 1:
			genListCreate(gStart);
			if (gStart)
				flag1 = true;
			break;
		case 2:
			if (flag1) {
				for (i = 1; i<5; ++i) {
					if (i == 1) {
						strcpy(dvizh, "nagore");
						subListCreate(dvizh, gStart, sUp);
					}
					if (i == 2) {
						strcpy(dvizh, "nadolu");
						subListCreate(dvizh, gStart, sDown);
					}
					if (i == 3) {
						strcpy(dvizh, "nadqsno");
						subListCreate(dvizh, gStart, sRight);
					}
					if (i == 4) {
						strcpy(dvizh, "nalqvo");
						subListCreate(dvizh, gStart, sLeft);
					}
				}
				cout << "\nOperaciqta e izvurshena!\n";
				flag2 = true;
			}
			else
				cout << "\nMolq izbirete purvo operaciq 1\n";
			break;
		case 3:
			if (flag1)
				printGenList(gStart);
			else
				cout << "\nMolq izbirete purvo operaciq 1\n";
			break;
		case 4:
			if (flag2) {
				cout << "Dvizhenie? "; cin >> dvizh;
				if (strcmp(dvizh, "nagore") == 0) {
					cout << "\nNAGORE: ";
					printSubList(sUp);
				}
				else if (strcmp(dvizh, "nadolu") == 0) {
					cout << "\nNADOLU: ";
					printSubList(sDown);
				}
				else if (strcmp(dvizh, "nadqsno") == 0) {
					cout << "\nNADQSNO: ";
					printSubList(sRight);
				}
				else if (strcmp(dvizh, "nalqvo") == 0) {
					cout << "\nNALQVO: ";
					printSubList(sLeft);
				}
				else
					cout << "\nGreshka pri vuvezhdane!\n";
			}
			else
				cout << "\nMolq izbirete purvo operaciq 2\n";
			break;
		case 5:
			ch = 'Y';
			while (ch == 'y' || ch == 'Y') {
				cout << "Dvizhenie: "; cin >> dvizh;
				if (strcmp(dvizh, "nagore") == 0) {
					x = VariantSpis(VarUp);
					for (i = 0; i<x; i++)
						SubToGen(dvizh, VarStart);
				}
				else if (strcmp(dvizh, "nadolu") == 0) {
					x = VariantSpis(VarDown);
					for (i = 0; i<x; i++)
						SubToGen(dvizh, VarStart);
				}
				else if (strcmp(dvizh, "nadqsno") == 0) {
					x = VariantSpis(VarRight);
					for (i = 0; i<x; i++)
						SubToGen(dvizh, VarStart);
				}
				else if (strcmp(dvizh, "nalqvo") == 0) {
					x = VariantSpis(VarLeft);
					for (i = 0; i<x; i++)
						SubToGen(dvizh, VarStart);
				}
				else cout << "\nGreshka pri vuvezhdane!\n";

				cout << "Shte produlzhite li vuvezhdaneto? (Y/N)";
				cin >> ch;
			}
			cout << "\nSpisuk s dvizheniqta...\n";
			printGenList(VarStart->next);
			cout << "\nNAGORE: ";
			printSubList(VarUp->next);
			cout << "\nNADOLU: ";
			printSubList(VarDown->next);
			cout << "\nNADQSNO: ";
			printSubList(VarRight->next);
			cout << "\nNALQVO: ";
			printSubList(VarLeft->next);
			break;
		}

	} while (choise != 0);

	system("pause");
	return 0;
}
