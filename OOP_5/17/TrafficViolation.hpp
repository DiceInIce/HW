#include <iostream>
#include <string>
#include <ctime>
#include <iomanip>

using namespace std;

class TrafficViolation {
private:
    string violationType;
    time_t date;
    string location;
    double fineAmount;

public:
    TrafficViolation(const string& type, const string& loc, double amount)
        : violationType(type), location(loc), fineAmount(amount) {
        date = time(nullptr);
    }

    void print() const {
        tm timeInfo;
        localtime_s(&timeInfo, &date);

        cout << "Тип: " << violationType
            << ", Дата: " << put_time(&timeInfo, "%Y-%m-%d %H:%M:%S")
            << ", Место: " << location
            << ", Штраф: " << fineAmount << " руб." << endl;
    }

    string getType() const { return violationType; }
    time_t getDate() const { return date; }
    string getLocation() const { return location; }
    double getFine() const { return fineAmount; }
};
