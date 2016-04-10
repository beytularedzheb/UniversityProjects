#include <stdlib.h>
#include <stdio.h>
#include <locale.h>

int numberOfProcesses, 
	totalCPUBurstTime, 
	*arrivalTime, 
	*CPUBurstTime, 
	*CPUBurstTimeCopy, 
	*processNumber, 
	minimumArrivalTime, 
	*processSequenceForEachSecond,
	*processFinishSequence,
	*waitingTime;

float averageTurnAroundTime,
	averageWaitingTime = 0;

/* ������� ������ �� ����������� �� ���� ���������� */
int *processNumberGantt, 
	*CPUBurstTimeGantt, 
	ganttSize;

void drawGanttChart();
void calculateProcessSequence();
int findAptProcessNumber(int);

int main()
{
	/* �������� */
	setlocale(LC_ALL, "bgr");
	
	int i, j, temp;

	printf("�������� ���� �� ��������� : ");
	scanf("%d", &numberOfProcesses);
	arrivalTime = (int*)malloc(sizeof(int) * numberOfProcesses);
	CPUBurstTime = (int*)malloc(sizeof(int) * numberOfProcesses);
	CPUBurstTimeCopy = (int*)malloc(sizeof(int) * numberOfProcesses);
	processNumber = (int*)malloc(sizeof(int) * numberOfProcesses);
	waitingTime = (int*)malloc(sizeof(int) * numberOfProcesses);
	processFinishSequence = (int*)malloc(sizeof(int) * numberOfProcesses);
	
	minimumArrivalTime = 2147483647;

	for (i = 0; i < numberOfProcesses; i++)
	{
		processFinishSequence[i] = -1;
		waitingTime[i] = 0;
		processNumber[i] = i;
		printf("\n�������� ������� �� ������ ����� %d\n", i + 1);
		printf("\n");
		printf("����� �� ���������� : ");
		scanf("%d", &arrivalTime[i]);
		printf("���������� ����� �� ���������� : ");
		scanf("%d", &CPUBurstTime[i]);
		CPUBurstTimeCopy[i] = CPUBurstTime[i];
		totalCPUBurstTime += CPUBurstTime[i];
		if (minimumArrivalTime > arrivalTime[i])
			minimumArrivalTime = arrivalTime[i];
	}
	processSequenceForEachSecond = (int*)malloc(sizeof(int)*totalCPUBurstTime);

	calculateProcessSequence();
	
	printf("\n������\t|\tTw\t|\tTr\n\n");
	for (i = 0; i < numberOfProcesses; i++)
	{
		printf("\nP[%d]\t|\t%d\t|\t%d", 
			processFinishSequence[i] + 1, 
			waitingTime[processFinishSequence[i]], 
			waitingTime[processFinishSequence[i]] + CPUBurstTimeCopy[processFinishSequence[i]]);
	}
	
	printf("\n\n������ �����, ����������� �� ��������� �� ��������� = %.2f", averageWaitingTime);
	printf("\n������ �������� ����� = %.2f\n\n", averageTurnAroundTime);

	drawGanttChart();
	
	/* ������������� �� ���������� ��������� ����� */
	free(arrivalTime); 
	free(CPUBurstTime);
	free(CPUBurstTimeCopy);
	free(processNumber);
	free(processSequenceForEachSecond);
	free(processFinishSequence);
	free(waitingTime);
	free(processNumberGantt);
	free(CPUBurstTimeGantt);
	
	return 0;
}

void calculateProcessSequence()
{
	int i, j, pNumber, prevProcess, tempCPUBurstTime, counter, prevProcesss;
	counter = 0;
	for (i = minimumArrivalTime; i < totalCPUBurstTime + minimumArrivalTime; i++)
	{
		pNumber = findAptProcessNumber(i);
		processSequenceForEachSecond[i - minimumArrivalTime] = pNumber;
		CPUBurstTime[pNumber]--;
		if (CPUBurstTime[pNumber] == 0)
		{
			processFinishSequence[counter++] = pNumber;
		}
		
		/* ����������� ����� �� ��������� �� ����� ������ */
		for (j = 0; j < numberOfProcesses; j++)
			if (CPUBurstTime[j] != 0 && arrivalTime[j] <= i && j != pNumber)
				waitingTime[j]++;
	}

	/* ����������� ������� �� �������� �� ���� ���������� */
	ganttSize = 1;
	prevProcess = processSequenceForEachSecond[0];
	for (i = 0; i < totalCPUBurstTime; i++)
	{
		if (prevProcess != processSequenceForEachSecond[i])
			ganttSize++;
		prevProcess = processSequenceForEachSecond[i];
	}

	/* �������� �� ����� �� �������� �� ���� ���������� */
	processNumberGantt = (int*)malloc(sizeof(int)*ganttSize);
	CPUBurstTimeGantt = (int*)malloc(sizeof(int)*ganttSize);

	/* �������� �� ������� � �������� �� ���� ���������� */
	prevProcess = processSequenceForEachSecond[0];
	tempCPUBurstTime = 0;
	counter = 0;
	for (i = 0; i < totalCPUBurstTime; i++)
	{
		if (prevProcess != processSequenceForEachSecond[i])
		{
			processNumberGantt[counter] = prevProcess;
			CPUBurstTimeGantt[counter] = tempCPUBurstTime;
			counter++;
			tempCPUBurstTime = 0;
		}
		tempCPUBurstTime++;
		prevProcess = processSequenceForEachSecond[i];
	}

	CPUBurstTimeGantt[ganttSize - 1] = tempCPUBurstTime;
	processNumberGantt[ganttSize - 1] = prevProcess;


	/* ����������� �� �������� ����� �� ��������� Tw � ���������� ����� Tr */
	averageWaitingTime = 0;
	averageTurnAroundTime = 0;
	for (i = 0; i < numberOfProcesses; i++)
	{
		averageWaitingTime += waitingTime[i];
		averageTurnAroundTime += waitingTime[i] + CPUBurstTimeCopy[i];
	}
	averageWaitingTime = averageWaitingTime / (float)numberOfProcesses;
	averageTurnAroundTime = averageTurnAroundTime / (float)numberOfProcesses;

}

int findAptProcessNumber(int currentTime)
{
	int i, min = 2147483647, pNumber;
	for (i = 0; i < numberOfProcesses; i++)
		if (arrivalTime[i] <= currentTime && min > CPUBurstTime[i] && CPUBurstTime[i] != 0)
		{
			min = CPUBurstTime[i];
			pNumber = i;
		}
		
	return pNumber;
}

void drawGanttChart()
{
	const int maxWidth = 100;
	int scalingFactor, i, counter, tempi, currentTime;
	printf("���� �������� : \n\n");

	scalingFactor = maxWidth / totalCPUBurstTime;
	for (i = 0; i < scalingFactor * totalCPUBurstTime + 2 + ganttSize; i++)
		printf("-");
	printf("\n|");
	counter = 0, tempi = 0;
	for (i = 0; i < scalingFactor * totalCPUBurstTime; i++)
		if (i == CPUBurstTimeGantt[counter] * scalingFactor + tempi)
		{
			counter++;
			tempi = i;
			printf("|");
		}
		else if (i == (CPUBurstTimeGantt[counter] * scalingFactor) / 2 + tempi)
			printf("P%d", processNumberGantt[counter] + 1);
		else
			printf(" ");
		printf("|");
		printf("\n");
		for (i = 0; i < scalingFactor * totalCPUBurstTime + 2 + ganttSize; i++)
			printf("-");
		printf("\n");

		/* �������� �� ��������� ������� */
		counter = 0;
		tempi = 0;
		currentTime = minimumArrivalTime;
		printf("%d", currentTime);
		for (i = 0; i < scalingFactor * totalCPUBurstTime; i++)
			if (i == CPUBurstTimeGantt[counter] * scalingFactor + tempi)
			{
				tempi = i;
				currentTime += CPUBurstTimeGantt[counter];
				counter++;
				printf("%2d", currentTime);
			}
			else
			{
				printf(" ");
			}
		currentTime += CPUBurstTimeGantt[counter];
		printf("%2d\n\n", currentTime);
}
