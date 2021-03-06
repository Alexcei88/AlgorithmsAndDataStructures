### Алгоритм возведения в степень

| Тест №    | iterative, ms | power of two + multiplication, ms | power of two, ms |
| --------- | :-----------: | :-------------------------------: | :--------------: |
| 0         |      31       |                 4                 |        0         |
| 1         |       0       |                 0                 |        0         |
| 2         |       0       |                 0                 |        0         |
| 3         |       0       |                 0                 |        0         |
| 4         |       0       |                 0                 |        0         |
| 5         |       2       |                 0                 |        0         |
| 6         |      23       |                 1                 |        0         |
| 7         |      231      |                33                 |        0         |
| 8         |     2267      |                456                |        0         |
| 9         |     22390     |               1478                |        0         |
| **Итого** |   **27270**   |             **1980**              |      **2**       |



### Алгоритм поиска чисел Фибоначчи

| Тест №    | Recursive, ms | Iterative, ms | Golden ratio, ms | Matrix, ms  |
| --------- | :-----------: | :-----------: | :--------------: | :---------: |
| 0         |       6       |       6       |        5         |      5      |
| 1         |       0       |       0       |        0         |      0      |
| 2         |       0       |       0       |        10        |      0      |
| 3         |       3       |       0       |        0         |      0      |
| 4         |       0       |       0       |        0         |      0      |
| 5         |       1       |       0       |        0         |      0      |
| 6         |       0       |       0       |        0         |      0      |
| 7         |       0       |       0       |        0         |      0      |
| 8         |       1       |       1       |        0         |      0      |
| 9         |      56       |       9       |        0         |      9      |
| 10        |     52515     |      219      |        0         |     47      |
| 11        |     долго     |     17061     |        1         |    1205     |
| 12        |     долго     |    3010632    |        6         |   136465    |
| **Итого** |   **долго**   | **3 027 930** |      **28**      | **137 735** |



### Алгоритмы поиска кол-ва простых чисел до N макс

| Тест №    | Optimized BruteForce, ms | With Array, ms | Eratosphen nloglogn, ms | Eratosphen nloglogn OptMemory, ms | EratosphenSuperOptimized, ms |
| --------- | :----------------------: | :------------: | :---------------------: | :-------------------------------: | :--------------------------: |
| 0         |            6             |       6        |            6            |                 6                 |              6               |
| 1         |            0             |       0        |            0            |                 0                 |              0               |
| 2         |            0             |       0        |            0            |                 0                 |              0               |
| 3         |            0             |       0        |            0            |                 0                 |              0               |
| 4         |            0             |       0        |            0            |                 0                 |              0               |
| 5         |            0             |       0        |            0            |                 0                 |              0               |
| 6         |            0             |       0        |            0            |                 0                 |              0               |
| 7         |            0             |       0        |            0            |                 0                 |              3               |
| 8         |            0             |       0        |            0            |                 0                 |              0               |
| 9         |            17            |       6        |            0            |                 2                 |              1               |
| 10        |           436            |      129       |            7            |                26                 |              9               |
| 11        |          11418           |      2470      |           91            |                277                |             103              |
| 12        |          301331          |     54863      |          1347           |               3057                |             1093             |
| 13        |          долго           |    1288154     |          13912          |               34546               |            23581             |
| 14        |          долго           |     73188      |          1592           |               3690                |             3376             |
| **Итого** |        **долго**         | **1 418 810**  |        **17000**        |             **41610**             |          **28180**           |