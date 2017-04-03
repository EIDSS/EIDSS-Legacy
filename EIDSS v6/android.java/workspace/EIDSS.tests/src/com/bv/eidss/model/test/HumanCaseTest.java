package com.bv.eidss.model.test;

/*
import static org.mockito.Mockito.when;
import static org.mockito.Mockito.doAnswer;
import static org.mockito.Mockito.mock;
import static org.mockito.Matchers.any;

import java.io.Serializable;
import java.util.Date;
import java.util.Stack;

import org.mockito.invocation.InvocationOnMock;
import org.mockito.stubbing.Answer;

import android.os.Parcel;
*/

import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.utils.DateHelpers;

import junit.framework.TestCase;

public class HumanCaseTest extends TestCase {

	public void testHumanCaseCreate(){
		HumanCase hc = HumanCase.CreateNew();
		assertNotNull(hc);
		assertEquals(CaseStatus.NEW, hc.getStatus());
		assertEquals("(new)", hc.getCaseID());
		assertNotNull(hc.getOfflineCaseID());
		assertEquals(true, hc.getChanged().booleanValue());
	}

	public void testHumanCaseValidate(){
		HumanCase hc = HumanCase.CreateNew();
		assertNotNull(hc);
		assertEquals(ValidateCode.DiagnosisMandatory, hc.Validate());
		hc.setTentativeDiagnosis(1);
		assertEquals(ValidateCode.LastNameMandatory, hc.Validate());
		hc.setFamilyName("");
		assertEquals(ValidateCode.LastNameMandatory, hc.Validate());
		hc.setFamilyName("  ");
		assertEquals(ValidateCode.LastNameMandatory, hc.Validate());
		hc.setFamilyName("name");
		assertEquals(ValidateCode.RegionMandatory, hc.Validate());
		hc.setRegionCurrentResidence(1);
		assertEquals(ValidateCode.RayonMandatory, hc.Validate());
		hc.setRayonCurrentResidence(1);
		assertEquals(ValidateCode.OK, hc.Validate());
		hc.setDateofBirth(DateHelpers.Date(DateHelpers.Today().getYear() + 1900 + 1, DateHelpers.Today().getMonth(), DateHelpers.Today().getDate()));
		assertEquals(ValidateCode.DateOfBirthCheckCurrent, hc.Validate());
		hc.setDateofBirth(DateHelpers.Date(DateHelpers.Today().getYear() + 1900, DateHelpers.Today().getMonth(), DateHelpers.Today().getDate()));
		assertEquals(ValidateCode.OK, hc.Validate());
		hc.setOnSetDate(DateHelpers.Date(DateHelpers.Today().getYear() + 1900 + 1, DateHelpers.Today().getMonth(), DateHelpers.Today().getDate()));
		assertEquals(ValidateCode.DateOfSymptomCheckCurrent, hc.Validate());
		hc.setOnSetDate(DateHelpers.Date(DateHelpers.Today().getYear() + 1900, DateHelpers.Today().getMonth(), DateHelpers.Today().getDate()));
		assertEquals(ValidateCode.OK, hc.Validate());
		
	}
	
	/*
	public void testHumanCaseParcelable(){
		final Stack<Object> s = new Stack<Object>();
		Parcel p = mock(Parcel.class);
		
		doAnswer(new Answer<Parcel>(){
			@Override
			public Parcel answer(InvocationOnMock invocation) throws Throwable {
				s.push((Integer)invocation.getArguments()[0]);
				return (Parcel)invocation.getMock();
			}}).when(p).writeInt(any(int.class));
		doAnswer(new Answer<Parcel>(){
			@Override
			public Parcel answer(InvocationOnMock invocation) throws Throwable {
				s.push((Long)invocation.getArguments()[0]);
				return (Parcel)invocation.getMock();
			}}).when(p).writeLong(any(long.class));
		doAnswer(new Answer<Parcel>(){
			@Override
			public Parcel answer(InvocationOnMock invocation) throws Throwable {
				s.push((String)invocation.getArguments()[0]);
				return (Parcel)invocation.getMock();
			}}).when(p).writeString(any(String.class));
		doAnswer(new Answer<Parcel>(){
			@Override
			public Parcel answer(InvocationOnMock invocation) throws Throwable {
				s.push((Date)invocation.getArguments()[0]);
				return (Parcel)invocation.getMock();
			}}).when(p).writeSerializable(any(Date.class));
		
		when(p.readInt()).thenAnswer(new Answer<Integer>(){
			@Override
			public Integer answer(InvocationOnMock invocation) throws Throwable {
				return (Integer)s.pop();
			}});
		when(p.readLong()).thenAnswer(new Answer<Long>(){
			@Override
			public Long answer(InvocationOnMock invocation) throws Throwable {
				return (Long)s.pop();
			}});
		when(p.readString()).thenAnswer(new Answer<String>(){
			@Override
			public String answer(InvocationOnMock invocation) throws Throwable {
				return (String)s.pop();
			}});
		when(p.readSerializable()).thenAnswer(new Answer<Serializable>(){
			@Override
			public Serializable answer(InvocationOnMock invocation) throws Throwable {
				return (Date)s.pop();
			}});
		
		HumanCase hc = HumanCase.CreateNew();
		assertNotNull(hc);
		hc.writeToParcel(p, 0);
		HumanCase hcp = HumanCase.CREATOR.createFromParcel(p);
		assertEquals(hc.getCaseID(), hcp.getCaseID());
	}
	*/
}
