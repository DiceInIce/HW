#include <iostream>

using namespace std;


void pancakeSort(int arr[],int arrSize) {
    int buff;
    int max;
    int maxArrayElement;

    for (int i = arrSize - 1; i >= 0; i--)
    {
        max = arr[i];
        maxArrayElement = i;
        //ищем макс эелемент
        for (int j = i; j >= 0; j--)
        {
            if (arr[j] > max)
            {
                max = arr[j];
                maxArrayElement = j;
            }
        }
        //переворачиваем часть массива, чтобы макс оказался сверху
        for (int flip = 0; flip <= maxArrayElement / 2; flip++)
        {
            //является ли верхний эелемент максимальным
            if (maxArrayElement == 0)
            {
                break;
            }

            buff = arr[flip];
            arr[flip] = arr[maxArrayElement - flip];
            arr[maxArrayElement - flip] = buff;
        }
        //переворачиваем опять, чтобы макс оказался внизу стопки
        for (int flip = 0; flip <= i / 2; flip++)
        {
            buff = arr[flip];
            arr[flip] = arr[i - flip];
            arr[i - flip] = buff;
        }
    }
}

void printArray(int arr[], int arrSize)
{
	for (int i = 0; i < arrSize; ++i)
		cout << arr[i] << " ";
}


int main()
{

	setlocale(LC_ALL, "");

	int arr[] = { 23, 10, 20, 11, 12, 6, 7 };
	int arrSize = size(arr);

	cout << "Изначальный массив: \n";
	printArray(arr, arrSize);

	pancakeSort(arr, arrSize);

	cout << "\n\nСортированный массив: \n";
	printArray(arr, arrSize);

	return 0;
}