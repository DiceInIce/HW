#pragma once
#include "Reservoir.h"
#include <vector>
#include <string>

void addReservoir(vector<Reservoir>& reservoirs, const Reservoir& r);
void deleteReservoir(vector<Reservoir>& reservoirs, int index);
void saveToTextFile(const vector<Reservoir>& reservoirs, const string& filename);
void saveToBinaryFile(const vector<Reservoir>& reservoirs, const string& filename);
void printAll(const vector<Reservoir>& reservoirs);

