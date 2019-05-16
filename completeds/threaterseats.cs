/*
 假定一个电影院有N排座位，每排座位的座位号为：ABC|DEFG|HJK
 字符串S包括所有已经已经被预订了的座位(1A 2D 4K...)
 找出剩下所有的连续的4个位置
*/
static int solution(int N, string S){
    int A = (int)'A';
    int J = 'J';
    int K = 'K';

    int firstRow = '1';

    var resvers = S.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    var totalSeats = new int[N, 10];

    foreach (var resver in resvers)
    {
        int row = resver[0];
        int column = resver[1];
        if (column == J || column == K)
        {
            column--;
        }

        totalSeats[row - firstRow, column - A] = 1;
    }

    var total = 0;

    for (int i = 0; i < N; i++)
    {
        //position 2
        var available = IsAvailable(totalSeats, i, 2);
        if (available)
        {
            total++;

            available = IsAvailable(totalSeats, i, 6);
            if (available)
            {
                total++;
            }
        }
        else if(IsAvailable(totalSeats, i, 4))
        {
            total++;
        }
        else if (IsAvailable(totalSeats, i, 6))
        {
            total++;
        }
    }

    return total;

}

static bool IsAvailable(int[,] totalSeats, int row, int position)
{
    return totalSeats[row, position - 1] == 0 && totalSeats[row, position] == 0 && totalSeats[row, position + 1] == 0 && totalSeats[row, position + 2] == 0;
}
