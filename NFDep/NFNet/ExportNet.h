//#include "NFINet.h"
//
//NFINet* 
//
////event call back event func define
//typedef int( * INIT_NET )( int num );
//
//INIT_NET p;
//
//__declspec(dllexport) int InitNet(INIT_NET p,char * str);
//__declspec(dllexport) int FinalNet(INIT_NET p,char * str);
//
//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////
//
//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////
//C++���壺
//    ////////////////////////////////////////////////////////
//    //�Զ�������ͷ�ļ� WebICAdapter.h
//#ifdef DLL_API
//#else
//#define DLL_API extern "C" __declspec(dllexport)
//#endif
//
//class WebICAdapter
//{
//public:
//    WebICAdapter(void);
//    ~WebICAdapter(void);
//    // ����add����
//    int add(int p1, int p2);
//};
//
//// ��������ʵ��ָ��
//DLL_API void* classInit(void **clsp);
//DLL_API int add(WebICAdapter* p, int p1, int p2);
//
//////////////////////////////////////////////////////////
////�Զ�������ͷ�ļ� WebICAdapter.cpp
////=========��������============
//// ��������ʵ��ָ��
//void* classInit(void **clsp)
//{
//    WebICAdapter* p = new WebICAdapter();
//    *clsp = p;
//    return clsp;
//}
//int add(WebICAdapter* p, int p1, int p2)
//{
//    return p->add(p1,p2);
//}
////==========���ʵ��===========
//WebICAdapter::WebICAdapter(void)
//{
//}
//WebICAdapter::~WebICAdapter(void)
//{
//}
//// ����add����
//int WebICAdapter::add(int p1, int p2)
//{
//    return p1+p2;
//}
//
//C#����͵��ã�
//    ////////////////////////////////////////////////////////
//    using System.Runtime.InteropServices;
//......
//    //--------------DLL�ӿڶ���-----------
//    [DllImport("SWWebICAdapter.dll", EntryPoint = "classInit", CharSet = 
//
//    CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
//public static extern int classInit(ref int clsPoint);
//
//[DllImport("SWWebICAdapter.dll", EntryPoint = "add", CharSet = CharSet.Auto, 
//
//           CallingConvention = CallingConvention.StdCall)]
//public static extern int add(ref int clsPoint, int p1, int p2);
//// DLL�е���ʵ��ָ��
//private int _clsPoint = 0;
//
//// -----------------------------------
//public SWWebIC()
//{
//    InitializeComponent();
//    // ��ʼ��DLL��ʵ��
//    _clsPoint = classInit(ref _clsPoint);
//}
//......
//    private void buttonDevice_Click(object sender, EventArgs e)
//{
//    int n = add(ref _clsPoint, 11, 12);
//    MessageBox.Show("��������" + n);
//}