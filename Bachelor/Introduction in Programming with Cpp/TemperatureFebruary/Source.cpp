#include <iostream>

const unsigned short HOURS = 6;	// брой колони - часове
const unsigned short LEAP_FEB = 29;	// брой дни във високосна година - февр.	
const unsigned short NO_LEAP_FEB = 28; // брой дни в невисокосна година - февр.

unsigned short days; // брой редове - дни
float *tempAverageFeb;	// средната темп. за всеки ден от 0-6
float **tempFeb; // всички отчетени температури за м. февр.

void Create()
{
	char leapYear;

	printf("Годината високосна ли е? (y/n) : ");
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
		printf("%d. февруари\n", i + 1);
		for (int j = 0; j < HOURS; j++)
		{
			printf("Температура за часовия интервал %d - %d : ",
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
		printf("\n -Средната температура за %d. февруари е %.2f C", 
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
	setlocale(LC_ALL, "BGR"); // за кирилица

	Create();

	Set();

	CalcAverageTemp();
	PrintAverageTemp();

	int coldestMorning = GetColdestMorning();
	printf("\n\nНай-студената сутрин (%.2f C) е била на:\n",
		tempAverageFeb[coldestMorning]);

	for (int i = 0; i < days; i++)
	{
		if (tempAverageFeb[coldestMorning] == tempAverageFeb[i])
		{
			printf("%d.февруари\n", i + 1);
		}
	}

	Free();
	return 0;
}