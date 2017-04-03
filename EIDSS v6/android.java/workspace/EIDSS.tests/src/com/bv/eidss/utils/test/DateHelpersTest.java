package com.bv.eidss.utils.test;

import java.util.Date;
import com.bv.eidss.utils.DateHelpers;
import junit.framework.TestCase;

public class DateHelpersTest extends TestCase {

	public void testToday(){
		Date d = DateHelpers.Today();
		assertNotNull(d);
		assertEquals(new Date().getYear(), d.getYear());
		assertEquals(new Date().getMonth(), d.getMonth());
		assertEquals(new Date().getDate(), d.getDate());
		assertEquals(new Date().getDay(), d.getDay());
		assertEquals(0, d.getHours());
		assertEquals(0, d.getMinutes());
		assertEquals(0, d.getSeconds());
	}
	
}
