using System;
using System.Reflection;

namespace N_TransS111
{
    public class ArraysHelper
    {
        /// <summary>
        /// Initializes a one-dimensional array.
        /// </summary>
        /// <typeparam name="TE">The type of the elements of the array like 'string' for instance.</typeparam>
        /// <param name="length">The length of the new array.</param>
        /// <returns>A new one-dimensional array with its values initialized to a default value.</returns>
        public static TE[] InitializeArray<TE>(int length)
        {
            return InitializeArray<TE[]>(new[] { length });
        }

        /// <summary>
        /// Initializes a one-dimensional array.
        /// </summary>
        /// <typeparam name="TE">The type of the elements of the array like 'string' for instance.</typeparam>
        /// <param name="length">The length of the new array.</param>
        /// <param name="lowerBound">The lower bound for the new array.</param>
        /// <returns>A new one-dimensional array with its values initialized to a default value.</returns>
        public static TE[] InitializeArray<TE>(int length, int lowerBound)
        {
            return InitializeArray<TE[]>(new[] { length }, new[] { lowerBound });
        }

        /// <summary>
        /// Initializes a one-dimensional array.
        /// </summary>
        /// <typeparam name="TE">The type of the elements of the array like 'string' for instance.</typeparam>
        /// <param name="length">The length of the new array.</param>
        /// <param name="constructorParams">The list of values to be sent to 
        /// the constructor of the item type of the array.</param>
        /// <returns>A new one-dimensional array with its values initialized to a default value.</returns>
        public static TE[] InitializeArray<TE>(int length, object[] constructorParams)
        {
            return InitializeArray<TE[]>(new[] { length }, constructorParams);
        }

        /// <summary>
        /// Initializes a one-dimensional array.
        /// </summary>
        /// <typeparam name="TE">The type of the elements of the array like 'string' for instance.</typeparam>
        /// <param name="length">The length of the new array.</param>
        /// <param name="lowerBound">The lower bound for the new array.</param>
        /// <param name="constructorParams">The list of values to be sent to 
        /// the constructor of the item type of the array.</param>
        /// <returns>A new one-dimensional array with its values initialized to a default value.</returns>
        public static TE[] InitializeArray<TE>(int length, int lowerBound, object[] constructorParams)
        {
            return InitializeArray<TE[]>(new[] { length }, new[] { lowerBound }, constructorParams);
        }

        /// <summary>
        /// Initializes a one-dimensional array.
        /// </summary>
        /// <typeparam name="TE">The type of the elements of the array like 'string' for instance.</typeparam>
        /// <param name="length">The length of the new array.</param>
        /// <param name="initValue">An initial value to set to each element.</param>
        /// <returns>A new one-dimensional array with its values initialized to initValue.</returns>
        public static TE[] InitializeArray<TE>(int length, object initValue)
        {
            return InitializeArray<TE[]>(new[] { length }, initValue);
        }

        /// <summary>
        /// Initializes a one-dimensional array.
        /// </summary>
        /// <typeparam name="TE">The type of the elements of the array like 'string' for instance.</typeparam>
        /// <param name="length">The length of the new array.</param>
        /// <param name="lowerBound">The lower bound for the new array.</param>
        /// <param name="initValue">An initial value to set to each element.</param>
        /// <returns>A new one-dimensional array with its values initialized to initValue.</returns>
        public static TE[] InitializeArray<TE>(int length, int lowerBound, object initValue)
        {
            return InitializeArray<TE[]>(new[] { length }, new[] { lowerBound }, initValue);
        }


        /// <summary>
        /// Initializes a multi-dimensional array.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions in the form 'string[,,]'.</typeparam>
        /// <param name="lengths">The length of each dimension.</param>
        /// <returns>A new multi-dimensional array with its values initialized to a default value.</returns>
        public static TA InitializeArray<TA>(int[] lengths) where TA : class
        {
            return InitializeArray<TA>(lengths, new object[] { });
        }

        /// <summary>
        /// Initializes a multi-dimensional array.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions in the form 'string[,,]'.</typeparam>
        /// <param name="lengths">The length of each dimension.</param>
        /// <param name="lowerBounds">The lower bounds to use for each dimension.</param>
        /// <returns>A new multi-dimensional array with its values initialized to a default value.</returns>
        public static TA InitializeArray<TA>(int[] lengths, int[] lowerBounds) where TA : class
        {
            return InitializeArray<TA>(lengths, lowerBounds, new object[] { });
        }

        /// <summary>
        /// Initializes a multi-dimensional array.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions in the form 'string[,,]'.</typeparam>
        /// <param name="lengths">The length of each dimension.</param>
        /// <param name="constructorParams">The list of values to be sent to 
        /// the constructor of the item type of the array.</param>
        /// <returns>A new multi-dimensional array with its values initialized to a default value.</returns>
        public static TA InitializeArray<TA>(int[] lengths, object[] constructorParams) where TA : class
        {
            if ((lengths == null) || (constructorParams == null))
                throw new NullReferenceException("AIS-Exception. Either 'lengths' or 'constructorParams' parameter is null");

            return InitializeArray<TA>(lengths, new int[lengths.Length], constructorParams);
        }

        /// <summary>
        /// Initializes a multi-dimensional array.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions in the form 'string[,,]'.</typeparam>
        /// <param name="lengths">The length of each dimension.</param>
        /// <param name="lowerBounds">The lower bounds to use for each dimension.</param>
        /// <param name="constructorParams">The list of values to be sent to 
        /// the constructor of the item type of the array.</param>
        /// <returns>A new multi-dimensional array with its values initialized to a default value.</returns>
        public static TA InitializeArray<TA>(int[] lengths, int[] lowerBounds, object[] constructorParams) where TA : class
        {
            if ((lengths == null) || (lowerBounds == null) || (constructorParams == null))
                throw new NullReferenceException("AIS-Exception. Either 'lengths', 'lowerBounds' or 'constructorParams' parameter is null");

            Type arrayType = typeof(TA);
            if (!arrayType.IsArray)
                throw new Exception("AIS-Exception. Array type is expected as parameter");

            Type itemType = arrayType.GetElementType();
            if (itemType == null)
                throw new NullReferenceException("AIS-Exception. itemType for the array couldn't be resolved");

            var valueProvider = new InitialValueProvider(itemType, constructorParams);

            //Only Primitive types and strings can be initialized with the same value, for other types a new instance 
            //will be used for each element
            if (itemType.IsPrimitive || itemType.Equals(typeof(string)))
                return InternalInitializeArray(lengths, lowerBounds, itemType, valueProvider.GetInitialValue()) as TA;
            return InternalInitializeArray(lengths, lowerBounds, itemType, valueProvider) as TA;
        }


        /// <summary>
        /// Initializes a multi-dimensional array.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions in the form 'string[,,]'.</typeparam>
        /// <param name="lengths">The length of each dimension.</param>
        /// <param name="initValue">The init value to use for each element in the array.</param>
        /// <returns>A new multi-dimensional array with its values initialized with initValue.</returns>
        public static TA InitializeArray<TA>(int[] lengths, object initValue) where TA : class
        {
            if (lengths == null)
                throw new NullReferenceException("AIS-Exception. 'lengths' parameter is null");

            return InitializeArray<TA>(lengths, new int[lengths.Length], initValue);
        }

        /// <summary>
        /// Initializes a multi-dimensional array.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions in the form 'string[,,]'.</typeparam>
        /// <param name="lengths">The length of each dimension.</param>
        /// <param name="lowerBounds">The lower bounds to use for each dimension.</param>
        /// <param name="initValue">The init value to use for each element in the array.</param>
        /// <returns>A new multi-dimensional array with its values initialized with initValue.</returns>
        public static TA InitializeArray<TA>(int[] lengths, int[] lowerBounds, object initValue) where TA : class
        {
            if ((lengths == null) || (lowerBounds == null))
                throw new NullReferenceException("AIS-Exception. Either 'lengths', 'lowerBounds' parameter is null");

            if (lengths.Length != lowerBounds.Length)
                throw new Exception("AIS-Exception. The length of 'lengths' and 'lowerBounds' parameters is different");

            Type arrayType = typeof(TA);
            if (!arrayType.IsArray)
                throw new Exception("AIS-Exception. Array type is expected as parameter");

            Type itemType = arrayType.GetElementType();
            if (itemType == null)
                throw new NullReferenceException("AIS-Exception. itemType for the array couldn't be resolved");

            return InternalInitializeArray(lengths, lowerBounds, itemType, initValue) as TA;
        }


        /// <summary>
        /// Internal method to initialize a multi-dimensional array.
        /// </summary>
        /// <param name="lengths">The length of each dimension.</param>
        /// <param name="lowerBounds">The lower bounds to use for each dimension.</param>
        /// <param name="itemType">The type to create the array.</param>
        /// <param name="value">The init value to use for each element in the array.</param>
        /// <returns>A new multi-dimensional array with its values initialized with initValue.</returns>
        private static Array InternalInitializeArray(int[] lengths, int[] lowerBounds, Type itemType, Object value)
        {
            object sampleValue;
            //Creates the array
            //Array res = Array.CreateInstance(itemType, lengths, lowerBounds);
            var res = Array.CreateInstance(itemType, lengths);

            //Initialize each element
            var upperBounds = new int[lowerBounds.Length];
            for (int i = 0; i < res.Rank; i++)
                upperBounds[i] = res.GetUpperBound(i);

            var indexes = new int[lengths.Length];
            Array.Copy(lowerBounds, indexes, lowerBounds.Length);

            var pos = res.Rank - 1;
            indexes[pos]--;
            pos = CalculateIndexes(ref indexes, pos, lowerBounds, upperBounds);

            //Won't initialize anything if the default values are the expected
            if (pos >= 0)
            {
                sampleValue = res.GetValue(indexes);
                var initValue = (value is InitialValueProvider) ? ((InitialValueProvider)value).GetInitialValue() : value;
                if (!(sampleValue == null && initValue == null) && (sampleValue == null || !sampleValue.Equals(initValue)))
                {
                    while (pos >= 0)
                    {
                        res.SetValue((value is InitialValueProvider) ? ((InitialValueProvider)value).GetInitialValue() : value, indexes);
                        pos = CalculateIndexes(ref indexes, pos, lowerBounds, upperBounds);
                    }
                }
            }
            return res;
        }


        /// <summary>
        /// Executes a RedimPreserve over an array.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions, for instance 'string[,,,]'.</typeparam>
        /// <param name="arraySource">The source array.</param>
        /// <param name="lengths">The length of the new dimensions.</param>
        /// <returns>The new array with the elements of the old one.</returns>
        public static TA RedimPreserve<TA>(TA arraySource, int[] lengths) where TA : class
        {
            if (lengths == null)
                throw new NullReferenceException("AIS-Exception. 'lengths' parameter is null");

            return RedimPreserve(arraySource, lengths, new int[lengths.Length], null);
        }


        /// <summary>
        /// Executes a RedimPreserve over an array.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions, for instance 'string[,,,]'.</typeparam>
        /// <param name="arraySource">The source array.</param>
        /// <param name="lengths">The length of the new dimensions.</param>
        /// <param name="constructorParams">Parameter to use when creating new instances for elements in this array.</param>
        /// <returns>The new array with the elements of the old one.</returns>
        public static TA RedimPreserve<TA>(TA arraySource, int[] lengths, object[] constructorParams) where TA : class
        {
            if (lengths == null)
                throw new NullReferenceException("AIS-Exception. 'lengths' parameter is null");

            return RedimPreserve(arraySource, lengths, new int[lengths.Length], constructorParams);
        }

        /// <summary>
        /// Executes a RedimPreserve over an array.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions, for instance 'string[,,,]'.</typeparam>
        /// <param name="arraySource">The source array.</param>
        /// <param name="lengths">The length of the new dimensions.</param>
        /// <param name="lowerBounds">The lower bound of the new dimensions.</param>
        /// <returns>The new array with the elements of the old one.</returns>
        public static TA RedimPreserve<TA>(TA arraySource, int[] lengths, int[] lowerBounds) where TA : class
        {
            return RedimPreserve(arraySource, lengths, lowerBounds, null);
        }

        /// <summary>
        /// Executes a RedimPreserve over an array.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions, for instance 'string[,,,]'.</typeparam>
        /// <param name="arraySource">The source array.</param>
        /// <param name="lengths">The length of the new dimensions.</param>
        /// <param name="lowerBounds">The lower bound of the new dimensions.</param>
        /// <param name="constructorParams">Parameter to use when creating new instances for elements in this array.</param>
        /// <returns>The new array with the elements of the old one.</returns>
        public static TA RedimPreserve<TA>(TA arraySource, int[] lengths, int[] lowerBounds, object[] constructorParams) where TA : class
        {
            Array res;

            Type arrayType;
            Type arrayElementType;
            if (typeof(TA).ToString() == "System.Array")
            {
                arrayType = null;
                arrayElementType = (arraySource as Array).GetValue(0).GetType();
            }
            else
            {
                arrayType = typeof(TA);
                arrayElementType = arrayType.GetElementType();
            }

            if (arraySource == null)
                return InitializeArray<TA>(lengths, lowerBounds);

            if (typeof(TA).ToString() != "System.Array")
                RunRedimPreserveVerifications(arraySource, arrayType, lengths, lowerBounds);
            var array = arraySource as Array;
            //There is something to copy
            if (array != null)
            {
                //res = Array.CreateInstance(arrayElementType, lengths, lowerBounds);
                res = Array.CreateInstance(arrayElementType, lengths);
                var valueProvider = new InitialValueProvider(arrayElementType, constructorParams);
                //Multiple dimensions
                if (array.Rank > 1)
                    FillsMultiDimensionalArray(array, res, valueProvider);
                else
                    FillsOneDimensionArray(array, res, valueProvider);
            }
            else
            {
                res = InitializeArray<TA>(lengths, lowerBounds) as Array;
            }
            return res as TA;
        }

        /// <summary>
        /// Fills the one-dimension targetArray with either matching cell values from 
        /// sourceArray or with a initial value.
        /// </summary>
        /// <param name="sourceArray">The array object containing the values to copy.</param>
        /// <param name="targetArray">The new array where to copy the values.</param>
        /// <param name="valueProvider">a <c>InitialValueProvider</c> object used to get 
        /// the default values for the new cells.</param>
        private static void FillsOneDimensionArray(Array sourceArray, Array targetArray, InitialValueProvider valueProvider)
        {
            Array.Copy(sourceArray, sourceArray.GetLowerBound(0), targetArray, sourceArray.GetLowerBound(0),
                       Math.Min(targetArray.GetLength(0), sourceArray.GetLength(0)));
            if (targetArray.Length > sourceArray.Length)
                for (int i = sourceArray.Length; i < targetArray.Length; i++)
                    targetArray.SetValue(valueProvider.GetInitialValue(), i + targetArray.GetLowerBound(0));
        }

        /// <summary>
        /// Fills the n-dimension targetArray with either matching cell values from 
        /// sourceArray or with a initial value.
        /// </summary>
        /// <param name="sourceArray">The array object containing the values to copy.</param>
        /// <param name="targetArray">The new array where to copy the values.</param>
        /// <param name="valueProvider">a <c>InitialValueProvider</c> object used to get
        /// the default values for the new cells.</param>
        private static void FillsMultiDimensionalArray(Array sourceArray, Array targetArray, InitialValueProvider valueProvider)
        {
            int rowsToCopy = GetFirstDimensionsSize(sourceArray);
            int originalLastDimensionSize = GetLastDimensionSize(sourceArray);
            int newLastDimensionSize = GetLastDimensionSize(targetArray);
            int newCells = newLastDimensionSize - originalLastDimensionSize;
            int lowerBound = sourceArray.GetLowerBound(0);
            // creates a new array with same dimensions than the target array (but a smaller one version) to hold the 
            // default values to copy
            Array arrayLen = Array.CreateInstance(typeof(Int32), targetArray.Rank);
            for (int i = 0; i < targetArray.Rank - 1; i++)
                arrayLen.SetValue(1, i);
            arrayLen.SetValue(targetArray.GetLength(targetArray.Rank - 1), targetArray.Rank - 1);
            Array defaultValues = Array.CreateInstance(targetArray.GetType().GetElementType(), (int[])arrayLen);

            for (int i = 0; i < rowsToCopy; i++)
            {
                //copies the values from source array to target aray
                Array.Copy(sourceArray, (i * originalLastDimensionSize) + lowerBound, targetArray, (i * newLastDimensionSize) + lowerBound,
                           Math.Min(originalLastDimensionSize, newLastDimensionSize));
                // fills the remaining cells with the default value
                if (newCells > 0)
                {
                    for (int k = 0; k < arrayLen.Length; k++)
                        arrayLen.SetValue(0, k); // initilizing the indixes to first array element (0 on all dimensions)
                    // sets up the default values array with new values (we delegate to the value provider the responsability to get either
                    // a new or an old instance.
                    for (int j = originalLastDimensionSize; j < newLastDimensionSize; j++)
                    {
                        arrayLen.SetValue(j - originalLastDimensionSize, arrayLen.Length - 1); // moves the index
                        defaultValues.SetValue(valueProvider.GetInitialValue(), (int[])arrayLen);
                    }
                    Array.Copy(defaultValues, 0, targetArray, (i * newLastDimensionSize) + originalLastDimensionSize + lowerBound, newCells);
                }
            }
        }

        /// <summary>
        /// Casts an array from one type to another.
        /// </summary>
        /// <typeparam name="TA">The type of the array including the dimensions in the form 'string[,,]'.</typeparam>
        /// <param name="srcArray">The source array to cast.</param>
        /// <returns>A new array with the correct new target type.</returns>
        public static TA CastArray<TA>(Array srcArray) where TA : class
        {
            Array res;
            try
            {
                if (srcArray == null) return null;

                Type arrayType = typeof(TA);
                if (!arrayType.IsArray)
                    throw new Exception("AIS-Exception. Array type is expected as parameter");

                Type itemType = arrayType.GetElementType();
                if (itemType == null)
                    throw new NullReferenceException("AIS-Exception. itemType for the array couldn't be resolved");

                var lengths = new int[srcArray.Rank];
                var lowerBounds = new int[srcArray.Rank];
                var upperBounds = new int[srcArray.Rank];
                for (var i = 0; i < srcArray.Rank; i++)
                {
                    lengths[i] = srcArray.GetLength(i);
                    lowerBounds[i] = srcArray.GetLowerBound(i);
                    upperBounds[i] = srcArray.GetUpperBound(i);
                }

                //Creates the array
                //res = Array.CreateInstance(itemType, lengths, lowerBounds);
                res = Array.CreateInstance(itemType, lengths);

                var indexes = new int[lengths.Length];
                Array.Copy(lowerBounds, indexes, lowerBounds.Length);

                int pos = res.Rank - 1;
                indexes[pos]--;
                pos = CalculateIndexes(ref indexes, pos, lowerBounds, upperBounds);

                while (pos >= 0)
                {
                    res.SetValue(Convert.ChangeType(srcArray.GetValue(indexes), itemType, null), indexes);
                    pos = CalculateIndexes(ref indexes, pos, lowerBounds, upperBounds);
                }
            }
            catch (Exception)
            {
                throw new Exception("AIS-Exception. Array casting is generating an exception");
            }

            return res as TA;
        }

        /// <summary>
        /// Calculate the indexes of the next element to copy.
        /// </summary>
        /// <param name="indexes">The list of the indexes in the different dimensions for 
        /// the element to copy.</param>
        /// <param name="pos">The current position within the list of indexes.</param>
        /// <param name="lBounds">The list of lower bounds to use as limit.</param>
        /// <param name="uBounds">The list of upper bounds to use as limit.</param>
        /// <returns>The current position or -1 if the operation failed which means 
        /// there is no next element to copy.</returns>
        private static int CalculateIndexes(ref int[] indexes, int pos, int[] lBounds, int[] uBounds)
        {
            indexes[pos]++;
            if (indexes[pos] > uBounds[pos])
            {
                indexes[pos] = lBounds[pos];
                pos--;
                if (pos >= 0)
                {
                    pos = CalculateIndexes(ref indexes, pos, lBounds, uBounds);
                    if (pos >= 0)
                        pos++;
                }
            }

            return pos;
        }

        /// <summary>
        /// Run some basic verifications on the parameters sent to RedimPreserve function.
        /// </summary>
        /// <param name="arrayPrototype">The source array to verify.</param>
        /// <param name="arrayType">The type of the source array.</param>
        /// <param name="lengths">The length of the dimensions.</param>
        /// <param name="lowerBounds">The lower bound of each dimension.</param>
        private static void RunRedimPreserveVerifications(object arrayPrototype, Type arrayType, int[] lengths, int[] lowerBounds)
        {
            if (!arrayType.IsArray)
                throw new Exception("AIS-Exception. Array type is expected as parameter");

            var itemType = arrayType.GetElementType();
            if (itemType == null)
                throw new NullReferenceException("AIS-Exception. itemType for the array couldn't be resolved");

            if ((lengths == null) || (lowerBounds == null))
                throw new NullReferenceException("AIS-Exception. Either 'lengths' or 'lowerBounds' parameter is null");

            if (lengths.Length != lowerBounds.Length)
                throw new Exception("AIS-Exception. The length of 'lengths' and 'lowerBounds' parameters is different");

            if ((arrayPrototype != null) && (arrayType.GetArrayRank() != lengths.Length))
                throw new Exception("AIS-Exception. Can't change the number of dimensions of the current array");
            var array = (Array)arrayPrototype;
            for (int i = 0; i < lengths.Length - 1; i++)
            {
                if (array.GetLength(i) != lengths[i])
                    throw new Exception("AIS-Exception.  Only last dimension can be modified.");
                if (array.GetLowerBound(i) != lowerBounds[i])
                    throw new Exception("AIS-Exception.  Only last dimension can be modified.");
            }
        }

        /// <summary>
        /// Gets the size for the first dimension for an array.
        /// </summary>
        /// <param name="array">The array to process.</param>
        /// <returns>The size of the first dimension of the array.</returns>
        private static int GetFirstDimensionsSize(Array array)
        {
            int result = 1;
            for (int i = 0; i < array.Rank - 1; i++)
                result = result * array.GetLength(i);
            return result;
        }

        /// <summary>
        /// Gets the size for the last dimension for an array.
        /// </summary>
        /// <param name="array">The array to process.</param>
        /// <returns>The size of the last dimension of the array.</returns>
        private static int GetLastDimensionSize(Array array)
        {
            return array.GetLength(array.Rank - 1);
        }

        /// <summary>
        /// The InitialValueProvider provides an initial value from several methods.
        /// Used for initialization of element types of arrays.
        /// </summary>
        private class InitialValueProvider
        {
            /// <summary>
            /// The Enumeration of the different kind of methods of initialization.
            /// </summary>
            private enum InitialValueMethod
            {
                String,
                Constructor,
                ValueType,
                CreateInstanceValueType
            } ;

            /// <summary>
            /// The Type of array's elements.
            /// </summary>
            private readonly Type _elementType;

            /// <summary>
            /// The list of values to be sent to the constructor used in the method CreateInstanceValueType.
            /// </summary>
            private Object[] _constructorParams;

            /// <summary>
            /// Indicates if provider was already initialized.
            /// </summary>
            private readonly bool _initialized;

            /// <summary>
            /// The InitializeMethod for the current provider.
            /// </summary>
            private InitialValueMethod _initializeMethod = InitialValueMethod.String;

            /// <summary>
            /// The Constructor method if constructor is gotten from elementType.
            /// </summary>
            private ConstructorInfo _constructor;

            /// <summary>
            /// Some Method used for initialization of the elementType, like "CreateInstance".
            /// </summary>
            private MethodInfo _method;

            /// <summary>
            /// Constructor for IniatialValueProvider.
            /// </summary>
            /// <param name="elementType">The type of the array's elements.</param>
            /// <param name="constructorParams">The list of values to be sent to the constructor of 
            /// the item type of the array.</param>
            public InitialValueProvider(Type elementType, Object[] constructorParams)
            {
                _elementType = elementType;
                _constructorParams = constructorParams;
                _initialized = false;
            }

            /// <summary>
            /// Gets the value of initialization according to the InitialValueMethod of this provider.
            /// </summary>
            /// <returns>The value of initialization.</returns>
            public Object GetInitialValue()
            {
                Initialize();
                switch (_initializeMethod)
                {
                    //case InitialValueMethod.CSFactory:
                    //    try
                    //    {
                    //        Type factoryType = null;
                    //        foreach (Type possibleFactory in elementType.Assembly.GetExportedTypes())
                    //        {
                    //            if (possibleFactory.BaseType == typeof(Artinsoft.VB6.Activex.ComponentServerFactory))
                    //            {
                    //                factoryType = possibleFactory;
                    //            }
                    //        }
                    //        MethodInfo mi = factoryType.GetMethod("CreateInstance", BindingFlags.Static | BindingFlags.Public);
                    //        MethodInfo miGeneric = mi.MakeGenericMethod(elementType);
                    //        return miGeneric.Invoke(null, new object[] { });
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        new Exception("Error while trying to get initial value for an array", ex);
                    //    }
                    //    break;
                    case InitialValueMethod.String:
                        return string.Empty;
                    case InitialValueMethod.Constructor:
                        return _constructor != null ? _constructor.Invoke(_constructorParams) : null;
                    case InitialValueMethod.ValueType:
                        return Activator.CreateInstance(_elementType);
                    case InitialValueMethod.CreateInstanceValueType:
                        return _method.Invoke(null, new object[] { });
                }
                return null;
            }

            /// <summary>
            /// Initialize this provider to be able to gets the intialization value.
            /// </summary>
            private void Initialize()
            {
                if (!_initialized)
                {
                    //initialized = true;
                    //if (elementType.BaseType == typeof(Artinsoft.VB6.Activex.ComponentClassHelper)
                    //    || elementType.BaseType == typeof(Artinsoft.VB6.Activex.ComponentSingleUseClassHelper)
                    //    || elementType.BaseType == typeof(Artinsoft.VB6.Activex.GlbComponentSingleUseClassHelper))
                    //{
                    //    initializeMethod = InitialValueMethod.CSFactory;
                    //}
                    //else
                    if (!_elementType.Equals(typeof(String)))
                    {
                        _initializeMethod = InitialValueMethod.Constructor;
                        //try for a constructor method
                        if (_constructorParams == null)
                            _constructorParams = new object[] { };

                        var typeArray = new Type[_constructorParams.Length];
                        int i = 0;
                        foreach (var param in _constructorParams)
                        {
                            typeArray[i] = param.GetType();
                            i++;
                        }

                        if ((_constructor = _elementType.GetConstructor(typeArray)) == null)
                        {
                            if (_elementType.IsValueType && _constructorParams.Length == 0)
                                _initializeMethod = (_method = _elementType.GetMethod("CreateInstance", BindingFlags.Static | BindingFlags.Public)) == null
                                                    ? InitialValueMethod.ValueType
                                                    : InitialValueMethod.CreateInstanceValueType;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get a copy of an array.
        /// </summary>
        /// <typeparam name="TE">They type of the array.</typeparam>
        /// <param name="array">The array to copy.</param>
        /// <returns>A copy of the array.</returns>
        public static TE[] CopyArray<TE>(TE[] array)
        {
            TE[] result = new TE[array.Length];
            array.CopyTo(result, 0);
            return result;
        }

        public static TE[,] CopyArray<TE>(TE[,] array)
        {
            TE[,] result = new TE[array.GetUpperBound(0), array.GetUpperBound(1)];
            array.CopyTo(result, 0);
            return result;
        }
    }
}
