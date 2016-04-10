 #include <algorithm>	// transform
 #include <iostream>	// cout
 #include <string>		// string
 using namespace std;

 // функция за задаване на ключа при шифъра на Виженер
 void setVigenereKey(string &key) {
	do {
		cout << "Въведете ключа при шифъра на Виженер:" << endl;
		cin >> key;
	} while (key == "");

	transform(key.begin(), key.end(), key.begin(), ::toupper);
}

 // функция за криптиране на текст с шифъра на Виженер
 string vigenereEnc(string text, string key) {
	string result = "";

	if (text != "") {
		for (int i = 0; i < text.length(); i++) {
			result += ((char)(((text[i] + key[i % key.length()]) % 26) + 'A'));
		}
	}

	return result;
}

 // функция за проверка дали числата x и y
 // са взаимно прости (най-голям общ делител)
 int gcd(int x, int y) {
	 if (y == 0)
		 return x;
	 else
		 return gcd(y, x % y);
 }

 // функция за задаване на ключа при афинния шифър
 void setAffineKey(int &a, int &b) {
	 cout << "Задайте ключа при афинния шифър:" << endl;
	 do {
		 cout << "a = ";
		 cin >> a;
	 } while (a <= 0);

	 do {
		 cout << "b = ";
		 cin >> b;
	 } while (b < 0);

	 if (gcd(a, 26) != 1) {
		 cout << "\nЧислото \'а\' = " << a << " и \'n\' = 26 "
			 << "не са взаимно прости числа!\n";
		 setAffineKey(a, b);
	 }
 }

 // функция за криптиране на текст с афинния шифър
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

// главна функция
int main() {
	setlocale(LC_ALL, "BGR"); // за кирилицата

	string plaintext, vigenereKey;
	int keyA, keyB;

	cout << "Въведете текста: ";
	getline(cin, plaintext);
	setAffineKey(keyA, keyB);
	setVigenereKey(vigenereKey);
	cout << endl
		<< vigenereEnc(affineEnc(preprocessing(plaintext), keyA, keyB), vigenereKey)
		<< endl;
	
	return 0;
}