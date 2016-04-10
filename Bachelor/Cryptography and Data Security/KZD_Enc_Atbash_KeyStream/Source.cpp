#include <algorithm>
#include <iostream>
#include <string>
using namespace std;

// функция за криптиране на текст - потоков шифър
string keyStreamEnc(string text, string key) {
	string result = "", currKey = key;
	for (int i = 0, j = 0; i < text.length(); i++, j++) {
		if (j == key.length()) {
			j = 0;
		}
		result += (char)(((text[i] + currKey[j]) % 26) + 'A');
		currKey[j] = result[i];
	}
	return result;
}

// фунцкия за криптиране на текст - "Atbash"
string atbash(string text) {
	string result = "";
	for (int i = 0; i < text.length(); i++) {
		result += ((char)(((-text[i] - 'A') % 26) + 'Z'));
	}
	return result;
}

// незначещите символи се премахват и се конвертират
// всички букви в големи
string preprocessing(string text) {
	string result = "";
	for (int i = 0; i < text.length(); i++) {
		char currChar = toupper(text[i]);
		if (isalpha(currChar)) {
			result += currChar;
		}
	}
	return result;
}

// главна програма
int main() {
	setlocale(LC_ALL, "bgr"); // за кирилицата
	string plaintext, streamKey;
	cout << "Задайте текста: ";
	getline(cin, plaintext);
	cout << "Задайте ключа при потоковия шифър: ";
	cin >> streamKey;
	transform(streamKey.begin(), streamKey.end(), streamKey.begin(), ::toupper);
	cout << keyStreamEnc(atbash(preprocessing(plaintext)), streamKey) << endl;
	return 0;
}