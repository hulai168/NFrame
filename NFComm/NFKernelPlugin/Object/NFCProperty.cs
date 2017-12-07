//-----------------------------------------------------------------------
// <copyright file="NFCProperty.cs">
//     Copyright (C) 2015-2015 lvsheng.huang <https://github.com/ketoo/NFrame>
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace NFrame
{
    public class NFCProperty : NFIProperty
    {
        public NFCProperty( NFGUID self, string strPropertyName, NFIDataList varData)
        {
            mSelf = self;
            msPropertyName = strPropertyName;
            mxData = new NFIDataList.TData(varData.GetType(0));

            switch (varData.GetType(0))
            {
                case NFIDataList.VARIANT_TYPE.VTYPE_INT:
                    mxData.Set(varData.IntVal(0));
                    break;
                case NFIDataList.VARIANT_TYPE.VTYPE_FLOAT:
                    mxData.Set(varData.FloatVal(0));
                    break;
                case NFIDataList.VARIANT_TYPE.VTYPE_DOUBLE:
                    mxData.Set(varData.DoubleVal(0));
                    break;
                case NFIDataList.VARIANT_TYPE.VTYPE_OBJECT:
                    mxData.Set(varData.ObjectVal(0));
                    break;
                case NFIDataList.VARIANT_TYPE.VTYPE_STRING:
                    mxData.Set(varData.StringVal(0));
                    break;
                default:
                    break;
            }
        }

        public NFCProperty(NFGUID self, string strPropertyName, NFIDataList.TData varData)
        {
            mSelf = self;
            msPropertyName = strPropertyName;
            mxData = new NFIDataList.TData(varData);
        }

        public override string GetKey()
        {
            return msPropertyName;
        }
		
		public override NFIDataList.VARIANT_TYPE GetType()
		{
            return mxData.GetType();
		}

        public override NFIDataList.TData GetData()
        {
            return mxData;
        }

        public override Int64 QueryInt()
        {
            if (NFIDataList.VARIANT_TYPE.VTYPE_INT == mxData.GetType())
            {
                return mxData.IntVal();
            }

            return NFIDataList.NULL_INT;
        }

        public override float QueryFloat()
        {
            if (NFIDataList.VARIANT_TYPE.VTYPE_FLOAT == mxData.GetType())
            {
                return (float)mxData.DoubleVal();
            }

            return (float)NFIDataList.EPS_DOUBLE;
        }

        public override double QueryDouble()
        {
            if (NFIDataList.VARIANT_TYPE.VTYPE_DOUBLE == mxData.GetType())
            {
                return mxData.DoubleVal();
            }

            return NFIDataList.EPS_DOUBLE;
        }

        public override string QueryString()
        {
            if (NFIDataList.VARIANT_TYPE.VTYPE_STRING == mxData.GetType())
            {
                return mxData.StringVal();
            }

            return NFIDataList.NULL_STRING;
        }

        public override NFGUID QueryObject()
        {
            if (NFIDataList.VARIANT_TYPE.VTYPE_INT == mxData.GetType())
            {
                return (NFGUID)mxData.ObjectVal();
            }

            return NFIDataList.NULL_OBJECT;
        }

        public override bool SetInt(Int64 value)
		{
            if (mxData.IntVal() != value)
            {
                NFIDataList.TData oldValue = new NFIDataList.TData(mxData);
                NFIDataList.TData newValue = new NFIDataList.TData(NFIDataList.VARIANT_TYPE.VTYPE_INT);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
				
			}

			return true;
		}

		public override bool SetFloat(float value)
		{
            if (mxData.DoubleVal() - value > NFIDataList.EPS_DOUBLE
                || mxData.DoubleVal() - value < -NFIDataList.EPS_DOUBLE)
            {
                NFIDataList.TData oldValue = new NFIDataList.TData(mxData);
                NFIDataList.TData newValue = new NFIDataList.TData(NFIDataList.VARIANT_TYPE.VTYPE_FLOAT);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
			}

			return true;
		}

		public override bool SetDouble(double value)
		{
            if (mxData.DoubleVal() - value > NFIDataList.EPS_DOUBLE
                || mxData.DoubleVal() - value < -NFIDataList.EPS_DOUBLE)
            {
                NFIDataList.TData oldValue = new NFIDataList.TData(mxData);
                NFIDataList.TData newValue = new NFIDataList.TData(NFIDataList.VARIANT_TYPE.VTYPE_DOUBLE);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
            }

			return true;
		}

		public override bool SetString(string value)
		{
            if (mxData.StringVal() != value)
            {
                NFIDataList.TData oldValue = new NFIDataList.TData(mxData);
                NFIDataList.TData newValue = new NFIDataList.TData(NFIDataList.VARIANT_TYPE.VTYPE_STRING);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
            }

			return true;
		}

		public override bool SetObject(NFGUID value)
		{
            if (mxData.ObjectVal() != value)
            {
                NFIDataList.TData oldValue = new NFIDataList.TData(mxData);
                NFIDataList.TData newValue = new NFIDataList.TData(NFIDataList.VARIANT_TYPE.VTYPE_OBJECT);
                newValue.Set(value);

                mxData.Set(value);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, msPropertyName, oldValue, newValue);
                }
            }

			return true;
		}

        public override bool SetData(NFIDataList.TData x)
        {
            if (NFIDataList.VARIANT_TYPE.VTYPE_UNKNOWN == mxData.GetType()
                || x.GetType() == mxData.GetType())
            {
                switch (mxData.GetType())
                {
                    case NFIDataList.VARIANT_TYPE.VTYPE_INT:
                        SetInt(x.IntVal());
                        break;
                    case NFIDataList.VARIANT_TYPE.VTYPE_STRING:
                        SetString(x.StringVal());
                        break;
                    case NFIDataList.VARIANT_TYPE.VTYPE_FLOAT:
                        SetFloat((float)x.DoubleVal());
                        break;
                    case NFIDataList.VARIANT_TYPE.VTYPE_DOUBLE:
                        SetDouble(x.DoubleVal());
                        break;
                    case NFIDataList.VARIANT_TYPE.VTYPE_OBJECT:
                        SetObject(x.ObjectVal());
                        break;
                    default:
                        break;
                }

                return true;
            }

            return false;
        }

		public override void RegisterCallback(PropertyEventHandler handler)
		{
			doHandleDel += handler;
		}

		PropertyEventHandler doHandleDel;

		NFGUID mSelf;
		string msPropertyName;
        NFIDataList.TData mxData;
    }
}