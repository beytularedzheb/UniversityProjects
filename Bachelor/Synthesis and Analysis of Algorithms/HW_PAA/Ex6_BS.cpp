#include <iostream>
using namespace std;

int BS(int A[], int value, int low, int high) {
	if (high < low) return -1;
	int mid = low + ((high - low) / 2);
	if (A[mid] > value)
		return BS(A, value, low, mid - 1);
	else if (A[mid] < value)
		return BS(A, value, mid + 1, high);
	else
		return mid;
}

int main(void)
{
	int a[] = { 1, 3, 4, 6, 9, 11, 12, 16 };
	cout << BS(a, 4, 0, 7) << endl;
	return 0;
}

/*
	Функцията BS() реализира бинарно (двоично) търсене в едномерен масив.
	Параметрите й са:
	  int A[] - масивът, в който ще се търси. Трябва да е сортиран!
	  int value - числото, което се търси
	  int low - долната граница
	  int high - горната граница
	  т.е между кои индекси на масива да се търси числото value.
	BS() връща като резултат индекса на числото value ако е намерено
	или -1 ако не е намерено.
	В този случай функцията ще връща 2, т.к числото 4 е на 2-ра позиция в масива.
*/
