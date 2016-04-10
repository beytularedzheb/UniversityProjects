#include <stdio.h>
#include <malloc.h>
#include <locale.h>

int main()
{
	setlocale(LC_ALL, "bgr");

	int time,
		*bt,
		*at,
		sum_bt = 0,
		smallest,
		n,
		i;
	int sum_turnaround = 0,
		sum_wait = 0;

	printf("Въведете броя на процесите : ");
	scanf("%d", &n);

	at = (int*)malloc(sizeof(int)*n+1);
	bt = (int*)malloc(sizeof(int)*n+1);

	for (i = 0; i < n; i++)
	{
		printf("\nВреме на пристигане на P%d : ", i + 1);
		scanf("%d", &at[i]);
		printf("Време за изпълнение на P%d : ", i + 1);
		scanf("%d", &bt[i]);
		sum_bt += bt[i];
	}

	bt[n + 1] = 9999;
	printf("\n\nПроцес\t|\tTw\t|\tTr\n\n");

	for (time = 0; time < sum_bt;)
	{
		smallest = n + 1;
		for (i = 0; i < n; i++)
		{
			if (at[i] <= time && bt[i] > 0 && bt[i] < bt[smallest])
				smallest = i;
		}
		if (smallest == n + 1)
		{
			time++;
			continue;
		}

		printf("P[%d]\t|\t%d\t|\t%d\n", smallest + 1, time - at[smallest], time + bt[smallest] - at[smallest]);
		sum_turnaround += time + bt[smallest] - at[smallest];
		sum_wait += time - at[smallest];
		time += bt[smallest];
		bt[smallest] = 0;
	}

	printf("\n\nСредно време на изчакване = %.2f", (float)sum_wait / n);
	printf("\nСредно оборотно време = %.2f\n", (float)sum_turnaround / n);

	free(at);
	free(bt);

	return 0;
}
