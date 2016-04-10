#include <algorithm>
#include <iostream>
#include <string>
using namespace std;

// ������� �� ���������� �� ����� - ������� �����
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

// ������� �� ���������� �� ����� - "Atbash"
string atbash(string text) {
	string result = "";
	for (int i = 0; i < text.length(); i++) {
		result += ((char)(((-text[i] - 'A') % 26) + 'Z'));
	}
	return result;
}

// ����������� ������� �� ��������� � �� �����������
// ������ ����� � ������
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

// ������ ��������
int main() {
	setlocale(LC_ALL, "bgr"); // �� ����������
	string plaintext, streamKey;
	cout << "������� ������: ";
	getline(cin, plaintext);
	cout << "������� ����� ��� ��������� �����: ";
	cin >> streamKey;
	transform(streamKey.begin(), streamKey.end(), streamKey.begin(), ::toupper);
	cout << keyStreamEnc(atbash(preprocessing(plaintext)), streamKey) << endl;
	return 0;
}