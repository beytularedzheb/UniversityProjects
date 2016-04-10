#include <iostream>
#include <string>
#include <locale>
using namespace std;

typedef struct Piece
{
	string name;
	string position;
	Piece *next;
} *PPiece;

void add(PPiece* head_ref, string name, string position)
{
	PPiece current, new_node;
	new_node = new Piece;
	new_node->name = name;
	new_node->position = position;

	if (*head_ref == NULL)
	{
		new_node->next = *head_ref;
		*head_ref = new_node;
	}
	else
	{
		current = *head_ref;
		while (current->next != NULL)
			current = current->next;
		new_node->next = current->next;
		current->next = new_node;
	}
}

void print(PPiece head_ref)
{
	while (head_ref)
	{
		cout << head_ref->name << " - "
			<< head_ref->position << endl;
		head_ref = head_ref->next;
	}
}

PPiece find(PPiece head_ref, string position)
{
	while (head_ref)
	{
		if (head_ref->position == position)
		{
			break;
		}
		head_ref = head_ref->next;
	}

	return head_ref;
}

void move(PPiece &head_ref, string fromPosition, string toPosition)
{
	PPiece p = head_ref, pdel;
	PPiece fromP = find(head_ref, fromPosition);
	PPiece toP = find(head_ref, toPosition);

	if (fromP)
	{
		fromP->position = toPosition;
		if (toP)
		{ // ��� ��� ����� ������ �� ������ �������
			if (head_ref == toP)
			{ // ��� ��������� �� ��������� � �����
				head_ref = head_ref->next;
				delete toP;
			}
			else
			{
				while (p)
				{
					if (p->next == toP)
					{
						pdel = p->next;
						p->next = p->next->next;
						delete pdel;
						break;
					}

					p = p->next;
				}
			}
		}
	}
	else
	{
		cout << endl << "�������� �� � ��������!";
	}
}

int main()
{
	setlocale(LC_ALL, "bgr");
	PPiece head = NULL;
	string name, position, toPosition;
	int choice;

	do {
		cout << "[1] �������� �� ���� ������" << endl;
		cout << "[2] ��������� �� ��������" << endl;
		cout << "[3] ����������� �� ������" << endl;
		cout << "[0] �����" << endl;
		cout << " -  �����: ";
		cin >> choice;
		cin.ignore();

		switch (choice) {
		case 1:
			cout << "������� ��������: ";
			getline(cin, name);

			cout << "������� ��������� �: ";
			cin >> position;

			add(&head, name, position);
			break;
		case 2:
			print(head);
			break;
		case 3:
			cout << "������� �������� ������� �� ��������: ";
			cin >> position;

			cout << "������� ������ ������� �� ��������: ";
			cin >> toPosition;

			move(head, position, toPosition);
			break;
		}
		cout << endl;
	} while (choice != 0);

	return 0;
}