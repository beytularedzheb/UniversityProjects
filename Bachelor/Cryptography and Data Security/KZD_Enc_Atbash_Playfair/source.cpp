#include <iostream>
#include <string>
using namespace std;
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

	cout << (char)toupper(mat[m][n]) << (char)toupper(mat[p][q]);
}

// функцията създава матрицата, съдържаща ключа и
// стартира криптирането - "Playfair"
void startPF(string str, string key) {
	char mat[siz][siz];
	int m, n, i, j;
	char temp;
	m = n = 0;
	for (i = 0; i < key.length(); i++)
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
		for (j = 0; j < key.length(); j++)
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
	for (i = 0; i < str.length(); i++)
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

// фунцкия за криптиране на текст - "Atbash"
string atbash(string text)
{
	string result = "";

	for (int i = 0; i < text.length(); i++)
	{
		result += ((char)((-(text[i] - 'a') % 26) + 'z'));
	}

	return result;
}

// финкцията взема само тези символи от текста, които
// са букви, а другите ги пропуска. Също така конвертира
// всички букви в малки
string preprocessing(string text)
{
	string result = "";

	for (int i = 0; i < text.length(); i++)
	{
		char currChar = tolower(text[i]);
		if (isalpha(currChar))
		{
			result += currChar;
		}
	}

	return result;
}

// главна програма
int main()
{
	string text, pfKey;
	do
	{
		cout << "Plaintext: ";
		getline(cin, text);
		text = preprocessing(text);
	} while (text == "");

	cout << "Playfair's key: ";
	cin >> pfKey;

	cout << endl << "Result:" << endl;	
	startPF(atbash(text), pfKey);
	cout << endl;

	return 0;
}
