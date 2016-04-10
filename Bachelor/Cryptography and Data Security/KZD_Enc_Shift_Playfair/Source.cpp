#include <iostream>
#include <string>
using namespace std;

char *abc = { "abcdefghijklmnopqrstuvwxyz" };

#define siz 5 // размер на матрицата

// функцията криптира двойка символи - "Playfair"
// и печата резултата
void playfair(char ch1, char ch2, char mat[siz][siz]) {
	int j, m, n, p, q, c, k;
	for (j = 0, c = 0; (c < 2) || (j < siz); j++)
		for (k = 0; k < siz; k++)
			if (mat[j][k] == ch1)
				m = j, n = k, c++;
			else if (mat[j][k] == ch2)
				p = j, q = k, c++;
	if (m == p) {
		n++, q++;
		if (n == siz) n = 0;
		else if (q == siz) q = 0;
	}
	else if (n == q) {
		m++, p++;
		if (m == siz) m = 0;
		else if (p == siz) p = 0;
	}
	else
		n += q, q = n - q, n -= q;

	cout << mat[m][n] << mat[p][q];
}

// функцията създава матрицата, съдържаща ключа и
// стартира криптирането - "Playfair"
void startPF(char *str, char *key) {
	char mat[siz][siz];
	int m, n, i, j;
	char temp;
	m = n = 0;
	for (i = 0; key[i] != '\0'; i++)
	{
		for (j = 0; j < i; j++)
			if (key[j] == key[i]) break;
		if (key[i] == 'j') key[i] = 'i';
		if (j >= i)
		{
			mat[m][n++] = key[i];
			if (n == siz)
				n = 0, m++;
		}
	}
	for (i = 97; i <= 122; i++)
	{
		for (j = 0; key[j] != '\0'; j++)
			if (key[j] == i)
				break;
			else if (i == 'j')
				break;
		if (key[j] == '\0')
		{
			mat[m][n++] = i;
			if (n == siz) n = 0, m++;
		}
	}
	for (i = 0; str[i] != '\0'; i++)
	{
		temp = str[i++];
		if (temp == 'j') temp = 'i';
		if (str[i] == '\0')
			playfair(temp, 'x', mat);
		else
		{
			if (str[i] == 'j') str[i] = 'i';
			if (temp == str[i])
			{
				playfair(temp, 'x', mat);
				i--;
			}
			else
				playfair(temp, str[i], mat);
		}
	}
}

// функция за криптира - транслиращ шифър
void shift(string plaintext) {
	char buf, s[256], *pch;
	string res1 = "";
	char chr[25]; // klyuchat pri Playfair
	int shKey; // klyuchat pri Shift cipher 

	do {
		cout << "Zadaite klyucha pri translirashtiq shifur: ";
		cin >> shKey;
	} while (shKey <= 0 || shKey > 26);

	for (int i = 0; i < plaintext.length(); i++) {
		if (isalpha(plaintext.c_str()[i])) {
			if (isupper(plaintext.c_str()[i]))
				buf = tolower(plaintext.c_str()[i]);
			else buf = plaintext.c_str()[i];

			for (int j = 0; j < 26; j++) {
				if (buf == abc[j])
					res1 += abc[(j + shKey) % 26];
			}
		}
		else res1 += " ";
	}

	cout << "\nZadaite klyucha pri Playfair: ";
	cin >> chr;
	strcpy(s, res1.c_str());
	pch = strtok(s, " ");
	while (pch) {
		char ss[256];
		strcpy(ss, pch);
		ss[strlen(pch)] = '\0';
		ss[strlen(pch) + 1] = '\0';
		startPF(ss, chr);
		cout << " ";
		pch = strtok(NULL, " ");
	}
}

// главна програма
int main() {
	string plaintext;
	cout << "Tekst: ";
	getline(cin, plaintext);
	shift(plaintext);

	cout << endl;
	return 0;
}
