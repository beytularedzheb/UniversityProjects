 #include <algorithm>	// transform
 #include <iostream>	// cout
 #include <string>		// string
 using namespace std;

 // ������� �� �������� �� ����� ��� ������ �� �������
 void setVigenereKey(string &key) {
	do {
		cout << "�������� ����� ��� ������ �� �������:" << endl;
		cin >> key;
	} while (key == "");

	transform(key.begin(), key.end(), key.begin(), ::toupper);
}

 // ������� �� ���������� �� ����� � ������ �� �������
 string vigenereEnc(string text, string key) {
	string result = "";

	if (text != "") {
		for (int i = 0; i < text.length(); i++) {
			result += ((char)(((text[i] + key[i % key.length()]) % 26) + 'A'));
		}
	}

	return result;
}

 // ������� �� �������� ���� ������� x � y
 // �� ������� ������ (���-����� ��� �������)
 int gcd(int x, int y) {
	 if (y == 0)
		 return x;
	 else
		 return gcd(y, x % y);
 }

 // ������� �� �������� �� ����� ��� ������� �����
 void setAffineKey(int &a, int &b) {
	 cout << "������� ����� ��� ������� �����:" << endl;
	 do {
		 cout << "a = ";
		 cin >> a;
	 } while (a <= 0);

	 do {
		 cout << "b = ";
		 cin >> b;
	 } while (b < 0);

	 if (gcd(a, 26) != 1) {
		 cout << "\n������� \'�\' = " << a << " � \'n\' = 26 "
			 << "�� �� ������� ������ �����!\n";
		 setAffineKey(a, b);
	 }
 }

 // ������� �� ���������� �� ����� � ������� �����
 string affineEnc(string text, int a, int b) {
	 string result = "";

	 for (int i = 0; i < text.length(); i++) {
		 result += ((char)(((a * text[i] - 'A' + b) % 26) + 'A'));
	 }

	 return result;
 }

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

// ������ �������
int main() {
	setlocale(LC_ALL, "BGR"); // �� ����������

	string plaintext, vigenereKey;
	int keyA, keyB;

	cout << "�������� ������: ";
	getline(cin, plaintext);
	setAffineKey(keyA, keyB);
	setVigenereKey(vigenereKey);
	cout << endl
		<< vigenereEnc(affineEnc(preprocessing(plaintext), keyA, keyB), vigenereKey)
		<< endl;
	
	return 0;
}