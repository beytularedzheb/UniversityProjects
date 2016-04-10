#include <iostream>

// ��������� �� ������ � �������
unsigned gcde(unsigned u, unsigned v)
{
	return (0 == v) ? u : gcde(v, u % v);
}

// ������� ��������
unsigned gcdb(unsigned u, unsigned v)
{
	if (u == v)
		return u;

	if (u == 0)
		return v;

	if (v == 0)
		return u;

	if (~u & 1)
	{
		if (v & 1) 
			return gcdb(u >> 1, v);
		else
			return gcdb(u >> 1, v >> 1) << 1;
	}

	if (~v & 1)
		return gcdb(u, v >> 1);

	if (u > v)
		return gcdb((u - v) >> 1, v);

	return gcdb((v - u) >> 1, u);
}

int main()
{
	setlocale(LC_ALL, "BGR");
	printf("������\n");
	printf("��� (2505, 9775) = %u\n", gcde(2505, 9775));
	printf("��� (10127, 8323) = %u\n", gcde(10127, 8323));

	printf("\n������� ���������\n");
	printf("��� (2505, 9775) = %u\n", gcdb(2505, 9775));
	printf("��� (10127, 8323) = %u\n", gcdb(10127, 8323));

	return 0;
}
