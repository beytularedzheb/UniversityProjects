#include <iostream>

const unsigned short HOURS = 6;	// ���� ������ - ������
const unsigned short LEAP_FEB = 29;	// ���� ��� ��� ��������� ������ - ����.	
const unsigned short NO_LEAP_FEB = 28; // ���� ��� � ����������� ������ - ����.

unsigned short days; // ���� ������ - ���
float *tempAverageFeb;	// �������� ����. �� ����� ��� �� 0-6
float **tempFeb; // ������ �������� ����������� �� �. ����.

void Create()
{
	char leapYear;

	printf("�������� ��������� �� �? (y/n) : ");
	scanf("%c", &leapYear);
	leapYear = toupper(leapYear);

	days = (leapYear == 'Y') ? LEAP_FEB : NO_LEAP_FEB;
	tempFeb = new float *[days];

	for (int i = 0; i < days; i++)
	{
		tempFeb[i] = new float[HOURS];
	}

	tempAverageFeb = new float[days];
}

void Free()
{
	for (int i = 0; i < days; i++)
	{
		delete[] tempFeb[i];
	}
	delete[] tempFeb;
	delete[] tempAverageFeb;
}

void Set()
{
	for (int i = 0; i < days; i++)
	{
		printf("%d. ��������\n", i + 1);
		for (int j = 0; j < HOURS; j++)
		{
			printf("����������� �� ������� �������� %d - %d : ",
				j, j + 1);
			scanf("%f", &tempFeb[i][j]);
		}
	}
}

void CalcAverageTemp()
{
	for (int i = 0; i < days; i++)
	{
		tempAverageFeb[i] = 0.0;
		for (int j = 0; j < HOURS; j++)
		{
			tempAverageFeb[i] += tempFeb[i][j];
		}

		tempAverageFeb[i] /= HOURS;
	}
}

void PrintAverageTemp()
{
	for (int i = 0; i < days; i++)
	{
		printf("\n -�������� ����������� �� %d. �������� � %.2f C", 
			i + 1, tempAverageFeb[i]);
	}
}

int GetColdestMorning()
{
	int index = 0;
	double coldestMorningTemp = INT_MAX;

	for (int i = 0; i < days; i++)
	{
		if (coldestMorningTemp > tempAverageFeb[i])
		{
			coldestMorningTemp = tempAverageFeb[i];
			index = i;
		}
	}

	return index;
}

int main()
{
	setlocale(LC_ALL, "BGR"); // �� ��������

	Create();

	Set();

	CalcAverageTemp();
	PrintAverageTemp();

	int coldestMorning = GetColdestMorning();
	printf("\n\n���-��������� ������ (%.2f C) � ���� ��:\n",
		tempAverageFeb[coldestMorning]);

	for (int i = 0; i < days; i++)
	{
		if (tempAverageFeb[coldestMorning] == tempAverageFeb[i])
		{
			printf("%d.��������\n", i + 1);
		}
	}

	Free();
	return 0;
}