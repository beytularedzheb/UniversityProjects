#include <stdio.h>
#include <iostream>

#define MAXN 100
const unsigned code1 = 98;
const unsigned code2 = 567;

void decodePerm(unsigned long num, unsigned n, unsigned perm[]) {
	unsigned long m, k;
	unsigned i, p[MAXN];
	for (i = 0; i < n; i++) p[i] = i + 1;
	k = n;
	do {
		m = n - k + 1;
		perm[k - 1] = num % m;
		if (k > 1) num /= m;
	} while (--k > 0);
	k = 0;
	do {
		m = perm[k]; perm[k] = p[m];
		if (k < n)
			for (i = m + 1; i < n; i++) p[i - 1] = p[i];
	} while (++k < n);
}

int main(void) {
	setlocale(LC_ALL, "BGR");

	unsigned i, dperm[MAXN];

	printf("Декодираме пермутацията отговаряща на числото %lu: ", code1);
	decodePerm(code1, 5, dperm);
	for (i = 0; i < 5; i++) printf("%u ", dperm[i]);
	printf("\n");

	printf("Декодираме пермутацията отговаряща на числото %lu: ", code2);
	decodePerm(code2, 6, dperm);
	for (i = 0; i < 6; i++) printf("%u ", dperm[i]);
	printf("\n");

	return 0;
}
