package com.bv.eidss.model.test;

import junit.framework.TestCase;
import static org.mockito.Mockito.when;
import static org.mockito.Mockito.mock;

import com.bv.eidss.model.BaseReference;
import android.database.Cursor;


public class BaseReferenceTest extends TestCase {

	public void testBaseReferenceCreate(){
		Cursor _cursor = mock(Cursor.class);
		when(_cursor.getColumnIndex("idfsBaseReference"))
			.thenReturn(1);
		when(_cursor.getColumnIndex("name"))
			.thenReturn(2);
		when(_cursor.getLong(1))
			.thenReturn(1000L);
		when(_cursor.getString(2))
			.thenReturn("Test Base Ref");
		
		BaseReference br = BaseReference.FromCursor(_cursor);
		assertNotNull(br);
		assertEquals(1000L, br.idfsBaseReference);
		assertEquals("Test Base Ref", br.name);
	}
	
}
