#include "reservoir_utils.h"
#include <fstream>
#include <iostream>

void addReservoir(vector<Reservoir>& reservoirs, const Reservoir& r) {
    reservoirs.push_back(r);
}

void deleteReservoir(vector<Reservoir>& reservoirs, int index) {
    if (index >= 0 && index < reservoirs.size())
        reservoirs.erase(reservoirs.begin() + index);
}

void saveToTextFile(const vector<Reservoir>& reservoirs, const string& filename) {
    ofstream out(filename);
    for (const auto& r : reservoirs) {
        out << r.getName() << "\n" << r.getType() << "\n"
            << r.getLength() << " " << r.getWidth() << " " << r.getDepth() << "\n";
    }
    out.close();
}

void saveToBinaryFile(const vector<Reservoir>& reservoirs, const string& filename) {
    ofstream out(filename, ios::binary);
    for (const auto& r : reservoirs) {
        size_t nameLen = r.getName().size();
        size_t typeLen = r.getType().size();
        out.write((char*)&nameLen, sizeof(nameLen));
        out.write(r.getName().c_str(), nameLen);
        out.write((char*)&typeLen, sizeof(typeLen));
        out.write(r.getType().c_str(), typeLen);
        double l = r.getLength(), w = r.getWidth(), d = r.getDepth();
        out.write((char*)&l, sizeof(l));
        out.write((char*)&w, sizeof(w));
        out.write((char*)&d, sizeof(d));
    }
    out.close();
}

void printAll(const vector<Reservoir>& reservoirs) {
    for (const auto& r : reservoirs) {
        r.display();
    }
}