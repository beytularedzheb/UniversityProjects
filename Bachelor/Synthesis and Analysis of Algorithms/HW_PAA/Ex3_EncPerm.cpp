#include <stdio.h>
#include <iostream>

#define MAXN 100

const unsigned perm1[MAXN] = { 2, 5, 3, 1, 4 };
const unsigned perm2[MAXN] = { 3, 5, 1, 4, 2, 6 };

unsigned long codePerm(unsigned n, const unsigned perm[])
{
	unsigned p[MAXN], i, pos;
	unsigned long r, result;
	result = 0;
	for (i = 0; i < n; i++) p[i] = i + 1;
	for (pos = 0; pos < n; pos++) {
		r = 0;
		while (perm[pos] != p[r]) r++;
		result = result * (n - pos) + r;
		for (i = r + 1; i < n; i++) p[i - 1] = p[i];
	}
	return result;
}

int main(void) {
	setlocale(LC_ALL, "BGR");

	printf("Пермутацията (2, 5, 3, 1, 4) се кодира като: %lu \n", codePerm(5, perm1));
	printf("Пермутацията (3, 5, 1, 4, 2, 6) се кодира като: %lu \n\n", codePerm(6, perm2));

	return 0;
}