#include <iostream>
#include "BinaryTree.hpp"

int main() {
    setlocale(LC_ALL, "");

    GAI_Database database;

    database.addViolation("А123БВ77", TrafficViolation("Превышение скорости", "ул. Ленина, д.10", 500));
    database.addViolation("А123БВ77", TrafficViolation("Проезд на красный", "ул. Гагарина, д.5", 1000));
    database.addViolation("В456ГД78", TrafficViolation("Парковка в неположенном месте", "пр. Мира, д.15", 300));
    database.addViolation("Е789ЖК99", TrafficViolation("Превышение скорости", "ш. Энтузиастов, д.20", 500));

    database.printAll();
    database.printByNumber("А123БВ77");
    database.printByRange("А100АА77", "В500ГД78");

    return 0;
}