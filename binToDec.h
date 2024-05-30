#pragma once
#include <iostream>
#include <math.h>

using namespace std;

int binaryToDecimal(string binary)
{
    int result = 0;
    if (binary[0] == 1)
        result -= pow(2, 10);

    for (int i = 1; i < 11; i++)
        if (binary[i] == '1')
            result += pow(2, (10 - i));

    return result;
}