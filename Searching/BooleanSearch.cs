using System;
using System.Collections.Generic;
using System.Text;

namespace Searching
{
    /*
     * The search algorithm on an inverted index follows there general steps (some steps may be absent for specific queiries):
     *      1. Vocabulary Search:
     *              the words and patterns present in the query are isolated and searched in the vocabulary.
     *              Notice that phrases and proximity queries are split into single words.
     * 
     *      2. Retrieval of Occurrences:
     *              The lists of the occurrences of all the words found are retrieved.
     * 
     *      3. Manipulation of Occurrences:
     *              The occurrences are proccessed to solve phrases, proximity, or boolean operations. If block
     *              addressing is used it may be necessary to directly search the text to find the information 
     *              missing from the occurrences (e.g. exact word positions to form phrases).
     */
    public class BooleanSearch
    {
        /*
         *          
         */
    }
}
