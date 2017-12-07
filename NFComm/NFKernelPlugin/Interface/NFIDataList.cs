﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFrame
{
    public abstract class NFIDataList
    {
        public enum VARIANT_TYPE
        {
            VTYPE_UNKNOWN,  // 未知
            VTYPE_INT,              // 32位整数
            VTYPE_FLOAT,            // 单精度浮点数
            VTYPE_DOUBLE,       // 双精度浮点数
            VTYPE_STRING,       // 字符串
            VTYPE_OBJECT,       // 对象ID
            VTYPE_MAX,
        };

        public class TData
        {
            public TData(TData x)
            {
                nType = x.nType;
                mData = x.mData;
            }

            public TData()
            {
                mData = new Object();
                nType = VARIANT_TYPE.VTYPE_UNKNOWN;
            }

            public TData(VARIANT_TYPE eType)
            {
                mData = new Object();
                nType = eType;
            }

            public VARIANT_TYPE GetType()
            {
                return nType;
            }

            public bool Set(Int64 value)
            {
                if(nType == VARIANT_TYPE.VTYPE_INT)
                {
                    mData = value;
                    return true;
                }

                return false;
            }

            public bool Set( float value)
            {
                if (nType == VARIANT_TYPE.VTYPE_FLOAT)
                {
                    mData = value;
                    return true;
                }

                return false;
            }

            public bool Set(double value)
            {
                if (nType == VARIANT_TYPE.VTYPE_DOUBLE)
                {
                    mData = value;
                    return true;
                }

                return false;
            }

            public bool Set(string value)
            {
                if (nType == VARIANT_TYPE.VTYPE_STRING)
                {
                    mData = value;
                    return true;
                }

                return false;
            }

            public bool Set(NFGUID value)
            {
                if (nType == VARIANT_TYPE.VTYPE_OBJECT)
                {
                    mData = value;
                    return true;
                }

                return false;
            }

            public Int64 IntVal()
            {
                if (nType == VARIANT_TYPE.VTYPE_INT)
                {

                    return (Int64)mData;
                }

                return NFIDataList.NULL_INT;
            }

            public double DoubleVal()
            {
                if (nType == VARIANT_TYPE.VTYPE_DOUBLE)
                {

                    return (double)mData;
                }

                return NFIDataList.NULL_DOUBLE;
            }

            public string StringVal()
            {
                if (nType == VARIANT_TYPE.VTYPE_STRING)
                {

                    return (string)mData;
                }

                return NFIDataList.NULL_STRING;
            }

            public NFGUID ObjectVal()
            {
                if (nType == VARIANT_TYPE.VTYPE_INT)
                {

                    return (NFGUID)mData;
                }

                return NFIDataList.NULL_OBJECT;
            }

            private VARIANT_TYPE nType;
            private Object mData;
        }

        public static readonly Int64 NULL_INT = 0;
        public static readonly double NULL_DOUBLE = 0.0;
        public static readonly string NULL_STRING = "";
        public static readonly NFGUID NULL_OBJECT = new NFGUID();
        public static readonly double EPS_DOUBLE = 0.0001;
        public static readonly TData NULL_TDATA = new TData();


        public abstract bool AddInt(Int64 value);
        public abstract bool AddFloat(float value);
        public abstract bool AddDouble(double value);
        public abstract bool AddString(string value);
        public abstract bool AddObject(NFGUID value);

        public abstract bool SetInt(int index, Int64 value);
        public abstract bool SetFloat(int index, float value);
        public abstract bool SetDouble(int index, double value);
        public abstract bool SetString(int index, string value);
        public abstract bool SetObject(int index, NFGUID value);

        public abstract Int64 IntVal(int index);
        public abstract float FloatVal(int index);
        public abstract double DoubleVal(int index);
        public abstract string StringVal(int index);
        public abstract NFGUID ObjectVal(int index);

		public abstract int Count();
		public abstract void Clear();
        public abstract VARIANT_TYPE GetType(int index);
        public abstract TData GetData(int index);
    }
}

