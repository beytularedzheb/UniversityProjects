#include <iostream>
#include <string.h>
#include <fstream>
using namespace std;

string LineTransDec(char *in, char key[40]) {
    char *out;
	int *keysort, s = 0;
	int in_len = strlen(in);
	int key_len = strlen(key);
	int o = strlen(in);

    for (int i = 0; i < key_len; i++)
        key[i] = tolower(key[i]);

	while (strlen(in) % strlen(key) != 0)
	{
		in[o] = 'X';
		o++;
	}

	in_len = strlen(in);
	out = new char[in_len + 1];
	keysort = new int [key_len];

	for (int i = 0; i < key_len; i++)
	{
		keysort[i] = (int)key[i] - 97;
	}

	for (int j = 0; j < 26; j++)
	{
		for (int i = 0; i < key_len; i++)
		{
			if (keysort[i] == j)
			{
				keysort[i] = s;
				s++;
			}
		}
	}

	for ( int n = 0; n < in_len; n += key_len)
	{
		for (int j = 0; j < key_len; j++)
		{
			for (int p = 0; p < key_len; p++)
			{
				if (j == keysort[p])
				{
					out[p + n] = in[j + n];
				}
			}
		}
	}
	
	out[in_len] = '\0';
	string result(out);
	delete out;
	delete []keysort;

	return result;
}

string AtbashDec(char *text)
{
	string result = "";
	for (int i = 0; i < strlen(text); i++)
	{
		if (isalpha(text[i]))
		{
			result += (char)((-(toupper(text[i]) - 'A') % 26) + 'Z');
		}
	}
	
	return result;
}

string ReadFile(string name)
{
	string str, result = "";
	ifstream infile;
	infile.open (name.c_str());
    while(!infile.eof())
    {
    	getline(infile, str);
    	for (int i = 0; i < str.length(); i++)
    	{
    		if (isalpha(str[i]))
    		{
    			result += str[i];
    		}
    	}
    }
	infile.close();

	return result;
}

int main()
{
	ofstream outfile;
	char key[40], *txt;
	cout << "Zadaite klyucha pri poredovo-transpozicionniq shifur: ";
	cin >> key;
	
	string text = ReadFile("input.txt");
	txt = new char(text.length() + 1);
	strcpy(txt, text.c_str());
	
	text = AtbashDec(txt);
	delete txt;
	txt = new char(text.length() + 1);
	strcpy(txt, text.c_str());

	outfile.open("output.txt");
	text = LineTransDec(txt, key);
	outfile << text;
	outfile.close();

	cout << endl << "Dannite sa zapisani v output.txt" << endl;
	delete txt;
 	return 0;
}

