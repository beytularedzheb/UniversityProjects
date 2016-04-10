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
	��������� BS() ��������� ������� (�������) ������� � ��������� �����.
	����������� � ��:
	  int A[] - �������, � ����� �� �� �����. ������ �� � ��������!
	  int value - �������, ����� �� �����
	  int low - ������� �������
	  int high - ������� �������
	  �.� ����� ��� ������� �� ������ �� �� ����� ������� value.
	BS() ����� ���� �������� ������� �� ������� value ��� � ��������
	��� -1 ��� �� � ��������.
	� ���� ������ ��������� �� ����� 2, �.� ������� 4 � �� 2-�� ������� � ������.
*/
