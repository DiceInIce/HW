#include "SHA256.hpp"

using namespace std;

uint32_t SHA256::rightRotate(uint32_t value, uint32_t bits) {
    return (value >> bits) | (value << (32 - bits));
}

string SHA256::hash(const std::string& input) {
    uint32_t h0 = 0x6a09e667;
    uint32_t h1 = 0xbb67ae85;
    uint32_t h2 = 0x3c6ef372;
    uint32_t h3 = 0xa54ff53a;
    uint32_t h4 = 0x510e527f;
    uint32_t h5 = 0x9b05688c;
    uint32_t h6 = 0x1f83d9ab;
    uint32_t h7 = 0x5be0cd19;

    // Преобразование входной строки в байты
    std::vector<uint8_t> message(input.begin(), input.end());

    // Сохраняем исходную длину в битах
    uint64_t original_length = message.size() * 8;

    // Добавляем бит '1' в конец сообщения
    message.push_back(0x80);

    // Дополняем сообщение нулями до длины, кратной 512 битам минус 64 бита
    while ((message.size() * 8) % 512 != 448) {
        message.push_back(0x00);
    }

    // Добавляем длину исходного сообщения в битах как 64-битное big-endian число
    for (int i = 0; i < 8; ++i) {
        message.push_back((original_length >> (56 - i * 8)) & 0xFF);
    }

    // Обработка сообщения блоками по 512 бит (64 байта)
    for (size_t i = 0; i < message.size(); i += 64) {
        // Подготовка массива слов (64 слова по 32 бита)
        uint32_t w[64] = { 0 };

        // Копируем данные из текущего блока в первые 16 слов
        for (size_t j = 0; j < 16; ++j) {
            w[j] = (message[i + j * 4] << 24) |
                (message[i + j * 4 + 1] << 16) |
                (message[i + j * 4 + 2] << 8) |
                (message[i + j * 4 + 3]);
        }

        // Расширяем первые 16 слов в оставшиеся 48 слов
        for (size_t j = 16; j < 64; ++j) {
            uint32_t s0 = rightRotate(w[j - 15], 7) ^ rightRotate(w[j - 15], 18) ^ (w[j - 15] >> 3);
            uint32_t s1 = rightRotate(w[j - 2], 17) ^ rightRotate(w[j - 2], 19) ^ (w[j - 2] >> 10);
            w[j] = w[j - 16] + s0 + w[j - 7] + s1;
        }

        // Инициализация рабочих переменных текущими значениями хеша
        uint32_t a = h0;
        uint32_t b = h1;
        uint32_t c = h2;
        uint32_t d = h3;
        uint32_t e = h4;
        uint32_t f = h5;
        uint32_t g = h6;
        uint32_t h = h7;

        // Основной цикл сжатия
        for (size_t j = 0; j < 64; ++j) {
            uint32_t S1 = rightRotate(e, 6) ^ rightRotate(e, 11) ^ rightRotate(e, 25);
            uint32_t ch = (e & f) ^ ((~e) & g);
            uint32_t temp1 = h + S1 + ch + k[j] + w[j];
            uint32_t S0 = rightRotate(a, 2) ^ rightRotate(a, 13) ^ rightRotate(a, 22);
            uint32_t maj = (a & b) ^ (a & c) ^ (b & c);
            uint32_t temp2 = S0 + maj;

            h = g;
            g = f;
            f = e;
            e = d + temp1;
            d = c;
            c = b;
            b = a;
            a = temp1 + temp2;
        }

        // Добавляем сжатый блок к текущему значению хеша
        h0 += a;
        h1 += b;
        h2 += c;
        h3 += d;
        h4 += e;
        h5 += f;
        h6 += g;
        h7 += h;
    }

    // Собираем итоговый хеш из всех частей
    std::stringstream ss;
    ss << std::hex << std::setfill('0');
    ss << std::setw(8) << h0
        << std::setw(8) << h1
        << std::setw(8) << h2
        << std::setw(8) << h3
        << std::setw(8) << h4
        << std::setw(8) << h5
        << std::setw(8) << h6
        << std::setw(8) << h7;

    return ss.str();
}