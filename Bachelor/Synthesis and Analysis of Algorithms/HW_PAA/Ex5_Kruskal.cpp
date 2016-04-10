#include <iostream>

struct node_info
{
	int no;
}*q = NULL, *r = NULL;

struct node
{
	node_info *pt;
	node *next;
}*top = NULL, *p = NULL, *np = NULL;

int flag = 0, v[8];

void push(node_info *ptr)
{
	np = new node;
	np->pt = ptr;
	np->next = NULL;
	if (top == NULL)
	{
		top = np;
	}
	else
	{
		np->next = top;
		top = np;
	}
}

node_info *pop()
{
	if (top == NULL)
	{
		printf("underflow\n");
	}
	else
	{
		p = top;
		top = top->next;
		return(p->pt);
		delete(p);
	}
}

int back_edges(int *v, int am[][8], int i, int k)
{
	q = new node_info;
	q->no = i;
	push(q);
	v[i] = 1;
	for (int j = 0; j < 8; j++)
	{
		if (am[i][j] == 1 && v[j] == 0)
		{
			back_edges(v, am, j, i);
		}
		else if (am[i][j] == 0)
			continue;
		else if ((j == k) && (am[i][k] == 1 && v[j] == 1))
			continue;
		else
		{
			flag = -1;
		}
	}
	r = pop();
	return(flag);
}

void init()
{
	for (int i = 0; i < 8; i++)
		v[i] = 0;
	while (top != NULL)
	{
		pop();
	}
}

int kruskals(int am[][8], int wm[][8])
{
	int ve = 1, min, temp, temp1, sum = 0;
	while (ve <= 7)
	{
		min = 999, temp = 0, temp1 = 0;
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if ((wm[i][j] < min) && wm[i][j] != 0)
				{
					min = wm[i][j];
					temp = i;
					temp1 = j;
				}
				else if (wm[i][j] == 0)
					continue;
			}
		}

		wm[temp][temp1] = wm[temp1][temp] = 999;
		am[temp][temp1] = am[temp1][temp] = 1;
		init();
		if (back_edges(v, am, temp, 0) < 0)
		{
			am[temp][temp1] = am[temp1][temp] = 0;
			flag = 0;
			continue;
		}
		else
		{
			printf("(%d, %d) ", temp + 1, temp1 + 1);
			ve++;
		}

		sum += min;
	}

	return sum;
}

int main()
{
	setlocale(LC_ALL, "BGR");

	int am[8][8], wm[8][8] =
	{
		{ 0, 12, 0, 14, 11, 0, 17, 8 },
		{ 12, 0, 9, 0, 12, 15, 10, 9 },
		{ 0, 9, 0, 18, 14, 31, 0, 9 },
		{ 14, 0, 18, 0, 0, 6, 23, 14 },
		{ 11, 12, 14, 0, 0, 15, 16, 0 },
		{ 0, 15, 31, 6, 15, 0, 8, 16 },
		{ 17, 10, 0, 23, 16, 8, 0, 22 },
		{ 8, 9, 9, 14, 0, 16, 22, 0 },
	};

	for (int i = 0; i < 8; i++)
		v[i] = 0;
	for (int i = 0; i < 8; i++)
	{
		for (int j = 0; j < 8; j++)
		{
			am[i][j] = 0;
		}
	}

	printf("\nЦената на минималното покриващо дърво е %d.\n", kruskals(am, wm));
	printf("\n");

	return 0;
}