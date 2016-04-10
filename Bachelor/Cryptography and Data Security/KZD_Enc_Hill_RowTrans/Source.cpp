#include <iostream>
#include <string>
#include <algorithm>
using namespace std;

char *abc = { "ABCDEFGHIJKLMNOPQRSTUVWXYZ" };

// функция за криптиране - шифър на Хил
string hillCipherEnc(char *ptt, int key[2][2]) {
	string result = "", s = ptt;
	char *pt;
	if ((strlen(ptt) % 2) != 0) {
		s += 'X';
	}
	pt = new char[s.length()];
	strcpy(pt, s.c_str());
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
		result += abc[buf1];
		result += abc[buf2];
	}

	delete[] nizPos;
	return result;
}

// функция за криптиране на текст с поредово-транзпозиционния шифър
void line_trans(char in[512], char key[100]) {
	char out[512];
	int *keysort, s = 0;
	int in_len = strlen(in);
	int key_len = strlen(key);
	int o = strlen(in);

	while (strlen(in) % strlen(key) != 0) {
		in[o] = 'X';
		o++;
		in[o] = '\0';
	}
	in_len = strlen(in);
	keysort = new int[key_len];
	for (int i = 0; i < key_len; i++) {
		keysort[i] = (int)key[i] - 'A';
	}
	for (int j = 0; j < 26; j++) {
		for (int i = 0; i < key_len; i++) {
			if (keysort[i] == j) {
				keysort[i] = s;
				s++;
			}
		}
	}
	int t = 0;
	for (int n = 0; n < in_len; n += key_len) {
		for (int j = 0; j < in_len; j++) {
			for (int p = 0; p < key_len; p++)
				if (j == keysort[p]) {
					out[t] = in[p + n];
					t++;
				}
		}
	}
	out[t] = '\0';
	cout << out << endl;
	delete[] keysort;
}

// финкцията взема само тези символи от текста, които
// са букви, а другите ги пропуска. Също така конвертира
// всички букви в главни
string preprocessing(string text) {
	string result = "";

	for (unsigned i = 0; i < text.length(); i++) {
		char currChar = toupper(text[i]);
		if (isalpha(currChar)) {
			result += currChar;
		}
	}

	return result;
}


// главна програма
int main() {
	string plaintext;
	char keyLine[100];
	int key[2][2];

	cout << "Tekst: ";
	getline(cin, plaintext);

	cout << "Zadaite klucha pri shifara na Hill:\n";
	for (int i = 0; i < 2; i++) {
		for (int j = 0; j < 2; j++) {
			cout << "[" << i + 1 << "]" << "[" << j + 1 << "] = ";
			cin >> key[i][j];
		}
	}
	string txt = preprocessing(plaintext);
	char *text = new char[txt.length()];
	strcpy(text, txt.c_str());

	txt = hillCipherEnc(text, key);
	text = new char[txt.length()];
	strcpy(text, txt.c_str());
	cout << "Zadaite klyucha pri poredovo-transpozicionniq shifur: ";
	cin >> keyLine;
	for (int i = 0; i < strlen(keyLine); i++) {
		keyLine[i] = toupper(keyLine[i]);
	}
	line_trans(text, keyLine);

	return 0;
}