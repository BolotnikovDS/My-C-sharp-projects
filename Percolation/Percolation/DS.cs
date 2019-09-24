namespace Percolation
{
    class DS
    {
        int[] parent;
        int[] rank;

        public DS(int N)
        {
            parent = new int[N];
            rank = new int[N];

            for (int i = 0; i < N; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int find_set(int v)
        {
            if (v == parent[v])
                return v;
            return parent[v] = find_set(parent[v]);
        }

        public void union_sets(int a, int b)
        {
            a = find_set(a);
            b = find_set(b);
            if (a != b)
            {
                if (rank[a] > rank[b])
                {
                    parent[b] = a;
                }
                else
                {
                    parent[a] = b;
                    if (rank[a] == rank[b])
                        rank[b]++;
                }
            }
        }
    }
}
