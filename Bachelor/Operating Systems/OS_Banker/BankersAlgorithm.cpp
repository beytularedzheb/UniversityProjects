#include <stdio.h>
#include <locale.h>
#include <stdlib.h>
#define MAX_PROC 5
#define MAX_RES 5

int curr[MAX_PROC][MAX_RES], maxclaim[MAX_PROC][MAX_RES], need[MAX_PROC][MAX_RES], avl[MAX_RES];
int request[MAX_RES] = { 0 };
int alloc[MAX_RES] = { 0 };
int maxres[MAX_RES], running[MAX_PROC], safe = 0;
int count = 0, i, j, exec, r, p;

void input() {
	do {
		printf("\n���� ������� (max %d): ", MAX_PROC);
		scanf("%d", &p);
	} while (p < 1 || p > MAX_PROC);

	for (i = 0; i < p; i++) {
		running[i] = 1;
		count++;
	}

	do {
		printf("\n���� ������� (max %d): ", MAX_RES);
		scanf("%d", &r);
	} while (r < 1 || r > MAX_RES);

	printf("\n�������: ");
	for (i = 0; i < r; i++) {
		scanf("%d", &maxres[i]);
	}

	printf("\n������������ �������:\n");
	for (i = 0; i < p; i++) {
		for (j = 0; j < r; j++) {
			scanf("%d", &curr[i][j]);
		}
	}

	printf("\n������������ ���� ������ �� ��������� �� �������:\n");
	for (i = 0; i < p; i++) {
		for (j = 0; j < r; j++) {
			scanf("%d", &maxclaim[i][j]);
			need[i][j] = maxclaim[i][j] - curr[i][j];
		}
	}

	for (i = 0; i < p; i++) {
		for (j = 0; j < r; j++) {
			alloc[j] += curr[i][j];
		}
	}

	for (i = 0; i < r; i++) {
		avl[i] = maxres[i] - alloc[i];
	}
}

void print() {
	printf("\n�������: ");
	for (i = 0; i < r; i++) {
		printf("\t%d", maxres[i]);
	}

	printf("\n������������ �������:\n");
	for (i = 0; i < p; i++) {
		for (j = 0; j < r; j++) {
			printf("\t%d", curr[i][j]);
		}

		printf("\n");
	}

	printf("\n������������ ���� ������ �� ��������� �� �������:\n");
	for (i = 0; i < p; i++) {
		for (j = 0; j < r; j++) {
			printf("\t%d", maxclaim[i][j]);
		}

		printf("\n");
	}

	printf("\n������������ ���� ������ �� ��������� �� �������:\n");
	for (i = 0; i < p; i++) {
		for (j = 0; j < r; j++) {
			printf("\t%d", need[i][j]);
		}

		printf("\n");
	}

	printf("\n������� �������:");
	for (i = 0; i < r; i++) {
		printf("\t%d", avl[i]);
	}
	printf("\n");
}

bool checkState() {
	int currAvl[MAX_RES];
	for (i = 0; i < r; i++) {
		currAvl[i] = avl[i];
	}

	while (count != 0) {
		safe = 0;
		for (i = 0; i < p; i++) {
			if (running[i]) {
				exec = 1;
				for (j = 0; j < r; j++) {
					if (need[i][j] - curr[i][j] > currAvl[j]) {
						exec = 0;
						break;
					}
				}
				if (exec) {
					printf("\n������%d �� ���������.", i + 1);
					running[i] = 0;
					count--;
					safe = 1;

					for (j = 0; j < r; j++) {
						currAvl[j] += curr[i][j];
					}

					break;
				}
			}
		}
		if (!safe) {
			printf("\n��������� �� �� � ��������� ���������.\n");
			return false;
		}
		else {
			printf("\n�������� � � ��������� ���������");
			printf("\n������� �������:");

			for (i = 0; i < r; i++) {
				printf("\t%d", currAvl[i]);
			}

			printf("\n");
		}
	}

	return true;
}

bool checkRequest(int processNo, bool getResource) {
	if (getResource) {
		for (i = 0; i < r; i++) {
			if (avl[i] < request[i]) {
				printf("\n���� ���������� �������!\n");
				return false;
			}
		}
	}
	else {
		for (i = 0; i < r; i++) {
			if (curr[processNo - 1][i] < request[i]) {
				printf("\n�������� �� ��������� � ������� �������!\n");
				return false;
			}
		}
	}

	return true;
}

void getResource(int processNo) {
	for (i = 0; i < r; i++) {
		avl[i] -= request[i];
		curr[processNo - 1][i] += request[i];
		need[processNo - 1][i] -= request[i];
	}

	count = 0;
	for (i = 0; i < p; i++) {
		running[i] = 1;
		count++;
	}
}

void freeResource(int processNo) {
	for (i = 0; i < r; i++) {
		avl[i] += request[i];
		curr[processNo - 1][i] -= request[i];
		need[processNo - 1][i] += request[i];
	}

	count = 0;
	for (i = 0; i < p; i++) {
		running[i] = 1;
		count++;
	}
}

int main()
{
	setlocale(LC_ALL, "bgr");
	int currentProcessNo;
	int choice;

	input();
	checkState();

	do {
		printf("%30s����\n", "");
		printf("%15s1. ��������� �� ����������� �� ��������� ���������\n", "");
		printf("%15s2. ��������� �� ������\n", "");
		printf("%15s3. ������������� �� ������\n", "");
		printf("%18s�������� �������� ��� 0 �� ����: ", "");
		scanf("%d", &choice); getchar();

		system("cls");

		switch (choice) {
		case 1:
			print();
			break;
		case 2:
			printf("\n�������� ������ �� ������� (1..%d): ", p);
			scanf("%d", &currentProcessNo);
			if (currentProcessNo < 1 || currentProcessNo > p) {
				printf("\n��������� ����� �� ������!\n");
				break;
			}
			printf("\n�������� ���������: ");
			for (i = 0; i < r; i++) {
				scanf("%d", &request[i]);
			}
			if (checkRequest(currentProcessNo, true)) {
				getResource(currentProcessNo);

				if (!checkState()) {
					for (i = 0; i < r; i++) {
						avl[i] += request[i];
						curr[currentProcessNo - 1][i] -= request[i];
						need[currentProcessNo - 1][i] += request[i];
					}
				}
			}
			break;
		case 3:
			printf("\n�������� ������ �� ������� (1..%d): ", p);
			scanf("%d", &currentProcessNo);
			if (currentProcessNo < 1 || currentProcessNo > p) {
				printf("\n��������� ����� �� ������!\n");
				break;
			}
			printf("\n�������� ���������: ");
			for (i = 0; i < r; i++) {
				scanf("%d", &request[i]);
			}

			if (checkRequest(currentProcessNo, false)) {
				freeResource(currentProcessNo);

				if (!checkState()) {
					for (i = 0; i < r; i++) {
						avl[i] -= request[i];
						curr[currentProcessNo - 1][i] += request[i];
						need[currentProcessNo - 1][i] -= request[i];
					}
				}
			}
			break;
		}

	} while (choice != 0);

	return 0;
}