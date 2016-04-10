#include <iostream>
#include <string>
using namespace std;

char *abc = { "ABCDEFGHIJKLMNOPQRSTUVWXYZ" };

// функция за криптиране - шифър на Хил
void hillCipherEnc(char *pt, int key[2][2]) {
	if ((strlen(pt) % 2) != 0)
		pt[strlen(pt)] = 'X';
	int *nizPos = new int[strlen(pt)];
	
	for (unsigned j = 0; j < strlen(pt); j++)
		for (unsigned k = 0; k < 26; k++)
			if (pt[j] == abc[k]) {
				nizPos[j] = k;
				break;
			}

	int buf1, buf2;

	for (unsigned i = 0; i < strlen(pt) - 1; i += 2) {
		buf1 = (nizPos[i] * key[0][0] + nizPos[i + 1] * key[1][0]) % 26;
		buf2 = (nizPos[i] * key[0][1] + nizPos[i + 1] * key[1][1]) % 26;
		cout << abc[buf1] << abc[buf2];
	}

	delete[] nizPos;
}

// функция за криптиране - транслиращ шифър
string shift(string plaintext) {
	char buf;
	string res1 = "";
	int shKey; // klyuchat pri Shift cipher 

	do {
		cout << "Zadaite klyucha pri translirashtiq shifur: ";
		cin >> shKey;
	} while (shKey <= 0 || shKey > 26);

	for (unsigned i = 0; i < plaintext.length(); i++) {
		if (isalpha(plaintext.c_str()[i])) {
			buf = toupper(plaintext.c_str()[i]);
			for (unsigned j = 0; j < strlen(abc); j++) {
				if (buf == abc[j])
					res1 += abc[(j + shKey) % 26];
			}
		}
		else res1 += " ";
	}

	return res1;
}

// главна програма
int main() {
	int key[2][2];
	string plaintext;
	char s[256], *pch;

	cout << "Tekst: ";
	getline(cin, plaintext);

	string r = shift(plaintext);

	cout << "Zadaite klucha pri shifara na Hill:\n";
	for (int i = 0; i < 2; i++) {
		for (int j = 0; j < 2; j++) {
			cout << "[" << i + 1 << "]" << "[" << j + 1 << "] = ";
			cin >> key[i][j];
		}
	}

	cout << endl << "Rezultat:" << endl;
	strcpy(s, r.c_str());
	pch = strtok(s, " ");
	while (pch) {
		char ss[256];
		strcpy(ss, pch);
		ss[strlen(pch)] = '\0';
		ss[strlen(pch) + 1] = '\0';
		hillCipherEnc(ss, key);
		cout << " ";
		pch = strtok(NULL, " ");
	}

	cout << endl;
	return 0;
}
