#include <StdAfx.h>

//�����������
bool cmp(int a,int b)
{
	return a>b;
}

int main()
{
	int a;
	int b[100];
	while(scanf("%d",&a)!=EOF)
	{
		if(a>100||a<=0)
		{
		    printf("�������򳤶Ȳ����Ϲ淶��1~100��");
		}
		else
		{
			for(int i=0;i<a;i++)
			{
				scanf("%d",&b[i]);
			}
			sort(b,b+a,cmp);
			for(int l=0;l<a;l++)
			{
			    printf("%d ",b[l]);
			}
			printf("\n");
		}
	}
	return 0;
}


