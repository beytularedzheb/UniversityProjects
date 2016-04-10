#include <iostream>
#include <vector>

using namespace std;

const unsigned NODE_COUNT = 13;

int graph[NODE_COUNT][NODE_COUNT] =
{
	{ 0, 3, 2, 3, 6, 0, 0, 0, 0, 0, 0, 0, 0 }, //0  | 3m3c,0,L
	{ 3, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0 }, //1  | 2m2mc,1m1c,R
	{ 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 }, //2  | 3m1c,2c,R
	{ 3, 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0 }, //3  | 3m,3c,R
	{ 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //4  | 3c,3m,R 
	{ 0, 2, 1, 2, 0, 0, 6, 5, 0, 0, 0, 0, 0 }, //5  | 3m2c,1c,L
	{ 0, 0, 0, 0, 0, 6, 0, 0, 4, 0, 0, 0, 0 }, //6  | 2c,3m1c,R
	{ 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0 }, //7  | 1m1c,2m2c,R
	{ 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 5, 0, 0 }, //8  | 2m2c,1m1c,L
	{ 0, 0, 0, 1, 0, 0, 0, 4, 0, 0, 6, 0, 0 }, //9  | 3m1c,2c,L
	{ 0, 0, 0, 0, 0, 0, 0, 0, 5, 6, 0, 2, 0 }, //10 | 1c,3m2c,R
	{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 3 }, //11 | 1m1c,2m2c,L
	{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0 }, //12 | 0,3m3c,R
};

string lblStates[NODE_COUNT] =
{
	"3m3c, 0, L", "2m2mc, 1m1c, R", "3m1c, 2c, R",
	"3m, 3c, R", "3c, 3m, R", "3m2c, 1c, L",
	"2c, 3m1c, R", "1m1c, 2m2c, R", "2m2c, 1m1c, L",
	"3m1c, 2c, L", "1c, 3m2c, R", "1m1c, 2m2c, L",
	"0, 3m3c, R",
};

struct Node {
	int index;
	double cost;
	double pathCost;
	vector<int> path;
};

vector<Node> getChilds(Node node)
{
	vector<Node> childs;
	for (int i = 0; i < NODE_COUNT; i++)
	{
		if (graph[node.index][i] > 0)
		{
			Node child = { i, graph[node.index][i], graph[node.index][i] + node.pathCost };
			child.path = node.path;
			child.path.push_back(node.index);
			childs.push_back(child);
		}	
	}

	return childs;
}

bool contains(vector<Node> nodeList, Node node)
{
	bool result = false;
	for (int i = 0; i < nodeList.size(); i++)
	{
		if (nodeList[i].index == node.index)
		{
			result = true;
			break;
		}
	}

	return result;
}

vector<Node> removeNode(vector<Node> nodeList, Node node)
{
	vector<Node> result;
	for (int i = 0; i < nodeList.size(); i++)
	{
		if (nodeList[i].index != node.index)
		{
			result.push_back(nodeList[i]);
		}
	}

	return result;
}

void printPath(Node node)
{
	for (int i = 0; i < node.path.size(); i++)
	{
		printf("%s\n", lblStates[node.path[i]].c_str());
	}
	printf("%s\n", lblStates[node.index].c_str());
}

void uniformCostSearch(int start, int  goal)
{
	Node source = { start, 0, 0 };

	vector<Node> open;
	open.push_back(source);
	vector<Node> closed;

	while (open.size() > 0)
	{
		Node x = open[0];
		open = removeNode(open, x);
		if (x.index == goal)
		{
			printPath(x);
			printf("\nCost: %.2f\n", x.pathCost);
			return;
		}
		else
		{
			vector<Node> childs = getChilds(x);
			closed.push_back(x);
			for (int i = 0; i < childs.size(); i++)
			{
				Node y = childs[i];

				if (!contains(open, y) &&
					!contains(closed, y))
				{
					open.push_back(y);
				}
				else
				{
					Node yc;
					bool update = false;
					for (int j = 0; j < open.size(); j++)
					{
						yc = open[j];
						if (y.index == yc.index &&
							y.pathCost < yc.pathCost)
						{
							update = true;
							break;
						}
					}

					if (update)
					{
						removeNode(open, yc);
						open.push_back(y);
					}
				}
			}
		}

		// sort open
		for (int k = 0; k < open.size() - 1; k++)
		{
			for (int h = 0; h < open.size() - k - 1; h++)
			{
				if (open[h].pathCost > open[h + 1].pathCost)
				{
					Node temp = open[h];
					open[h] = open[h + 1];
					open[h + 1] = temp;
				}
			}
		}
	}
}

int main()
{
	uniformCostSearch(0, 12);

	return 0;
}