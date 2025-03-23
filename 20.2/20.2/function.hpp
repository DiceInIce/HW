#ifndef FUNCTION_HPP
#define FUNCTION_HPP

#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

	#ifdef INTEGER
	#define FillArray FillArrayInt
	#define ShowArray ShowArrayInt
	#define MinElement MinElementInt
	#define MaxElement MaxElementInt
	#define SortArray SortArrayInt
	#define EditArray EditArrayInt
	#elif defined(CHAR)
	#define FillArray FillArrayChar
	#define ShowArray ShowArrayChar
	#define MinElement MinElementChar
	#define MaxElement MaxElementChar
	#define SortArray SortArrayChar
	#define EditArray EditArrayChar
	#elif defined(DOUBLE)
	#define FillArray FillArrayDouble
	#define ShowArray ShowArrayDouble
	#define MinElement MinElementDouble
	#define MaxElement MaxElementDouble
	#define SortArray SortArrayDouble
	#define EditArray EditArrayDouble
	#endif

void FillArrayInt(int*, int);
void ShowArrayInt(int*, int);
int MinElementInt(int*, int);
int MaxElementInt(int*, int);
void SortArrayInt(int*, int);
void EditArrayInt(int*, int, int, int);

void FillArrayChar(char*, int);
void ShowArrayChar(char*, int);
char MinElementChar(char*, int);
char MaxElementChar(char*, int);
void SortArrayChar(char*, int);
void EditArrayChar(char*, int, char, int);

void FillArrayDouble(double*, int);
void ShowArrayDouble(double*, int);
double MinElementDouble(double*, int);
double MaxElementDouble(double*, int);
void SortArrayDouble(double*, int);
void EditArrayDouble(double*, int, double, int);

#endif