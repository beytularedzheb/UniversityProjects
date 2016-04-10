#include <iostream>
#include <string>
using namespace std;

typedef struct Message
{
	char msg[2];
	Message *next;
} *PMessage;

void Add(PMessage* head_ref, string msg)
{
	PMessage current, new_node;
	new_node = new Message;
	strcpy(new_node->msg, msg.c_str());

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

void Print(PMessage head_ref)
{
	while (head_ref)
	{
		cout << head_ref->msg;
		head_ref = head_ref->next;
	}
}

void Encode(PMessage &head_ref, string code)
{
	PMessage new_item, p = head_ref;

	while (p && strlen(p->msg) > 1)
	{
		new_item = new Message;
		strcpy(new_item->msg, code.c_str());
		new_item->next = p->next;
		p->next = new_item;
		p = p->next->next;
	}
}

void Decode(PMessage &head_ref, string code)
{
	PMessage p = head_ref, pdel;

	while (p && strlen(p->msg) > 1)
	{
		pdel = p->next;
		p->next = p->next->next;
		delete pdel;
		p = p->next;
	}
}

int main()
{
	PMessage head = NULL;
	string fullMsg, code;
	cout << "Molq vuvedete izrechenieto: ";
	getline(cin, fullMsg);

	for (int i = 0; i < fullMsg.length(); i += 2)
	{
		Add(&head, fullMsg.substr(i, 2));
	}
	cout << "Molq vuvedete kodovata duma: ";
	cin >> code;

	cout << "Kodiranoto izrechenie e:" << endl;
	Encode(head, code);
	Print(head);

	cout << endl << "Dekodiranoto izrechenie e:" << endl;
	Decode(head);
	Print(head);
	cout << endl;

	return 0;
}