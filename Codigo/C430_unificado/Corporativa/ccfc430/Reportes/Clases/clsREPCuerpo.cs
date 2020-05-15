using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsREPCuerpo
	{
	
		private int mvarRenglonesI = 0; //local copy
		private int mvarColumnasI = 0; //local copy
		private colREPLineasREN mvarLineasREN = new colREPLineasREN();
		
		
		
		
		public colREPLineasREN LineasREN
		{
			get
			{
				if (mvarLineasREN == null)
				{
                    //AIS-541 NGONZALEZ
					mvarLineasREN = new colREPLineasREN();
				}
				return mvarLineasREN;
			}
			set
			{
                //AIS-541 NGONZALEZ
				mvarLineasREN = value;
			}
		}
		
		
		
		
		
		
		public int ColumnasI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.ColumnasI
				return mvarColumnasI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.ColumnasI = 5
				mvarColumnasI = value;
			}
		}
		
		
		
		
		
		
		public int RenglonesI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.RenglonesI
				mvarRenglonesI = LineasREN.Count;
				return mvarRenglonesI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.RenglonesI = 5
				mvarRenglonesI = value;
			}
		}
		
		
		
		~clsREPCuerpo(){
            //AIS-541 NGONZALEZ
			mvarLineasREN = null;
		}
}
}