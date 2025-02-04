#include <iostream>
#include <algorithm>
#include <ctime>


using namespace std;

const int matrixSize = 5;

void initMatrix(int matrix[matrixSize][matrixSize]) {
	for (int i = 0; i < matrixSize; i++) {
		for (int j = 0; j < matrixSize; j++) {
			matrix[i][j] = rand() % 100;
		}
	}
}

void initMatrix(double matrix[matrixSize][matrixSize]) {
	for (int i = 0; i < matrixSize; i++) {
		for (int j = 0; j < matrixSize; j++) {
			matrix[i][j] = (rand() % 1000) / 10.0;
		}
	}
}

void initMatrix(char matrix[matrixSize][matrixSize]) {
	for (int i = 0; i < matrixSize; i++) {
		for (int j = 0; j < matrixSize; j++) {
			matrix[i][j] = 'A' + rand() % 26;
		}
	}
}


template <typename T> void printMatrix(T matrix[matrixSize][matrixSize]) {
	for (int i = 0; i < matrixSize; i++) {
		for (int j = 0; j < matrixSize; j++) {
			cout << matrix[i][j] << "\t";
		}
		cout << endl;
	}
}

template <typename T> void findMinMax(T matrix[matrixSize][matrixSize], T& min, T& max) {
	min = matrix[0][0];
	max = matrix[0][0];

	for (int i = 0; i < matrixSize; i++) {
		if (matrix[i][i] < min) min = matrix[i][i];
		if (matrix[i][i] > max) max = matrix[i][i];
	}
}

template <typename T> void sortRows(T matrix[matrixSize][matrixSize]) {
	for (int i = 0; i < matrixSize; i++) {
		sort(matrix[i], matrix[i] + matrixSize);
	}
}

void main()
{
	setlocale(LC_ALL, "");
	srand(time(0));



	int intMatrix[matrixSize][matrixSize];
	double doubleMatrix[matrixSize][matrixSize];
	char charMatrix[matrixSize][matrixSize];

	initMatrix(intMatrix);
	initMatrix(doubleMatrix);
	initMatrix(charMatrix);

	cout << "Int матрица:" << endl;
	printMatrix(intMatrix);

	cout << "\nDouble матрица:" << endl;
	printMatrix(doubleMatrix);

	cout << "\nChar матрица:" << endl;
	printMatrix(charMatrix);




	int minInt, maxInt;
	double minDouble, maxDouble;
	char minChar, maxChar;

	findMinMax(intMatrix, minInt, maxInt);
	findMinMax(doubleMatrix, minDouble, maxDouble);
	findMinMax(charMatrix, minChar, maxChar);

	cout << "\nInt: min = " << minInt << ", max = " << maxInt << endl;
	cout << "Double: min = " << minDouble << ", max = " << maxDouble << endl;
	cout << "Char: min = " << minChar << " (" << (int)minChar << "), max = " << maxChar << " (" << (int)maxChar << ")" << endl;

	sortRows(intMatrix);
	sortRows(doubleMatrix);
	sortRows(charMatrix);

	cout << "\nОтсортированная int матрица:" << endl;
	printMatrix(intMatrix);

	cout << "\nОтсортированная double матрица:" << endl;
	printMatrix(doubleMatrix);

	cout << "\nОтсортированная char матрица:" << endl;
	printMatrix(charMatrix);

}